// ------------------------------------------------------------------------------
// 
// Copyright (c) Microsoft Corporation.
// All rights reserved.
// 
// This code is licensed under the MIT License.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
// ------------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.Identity.MsalApiServer.Attributes;
using Microsoft.Identity.MsalApiServer.Models;
using Newtonsoft.Json;

namespace Microsoft.Identity.MsalApiServer.Controllers
{
    /// <summary>
    /// </summary>
    [ApiController]
    public class PublicClientApiController : Controller
    {
        private static readonly ConcurrentDictionary<string, IPublicClientApplication> _pcaMap =
            new ConcurrentDictionary<string, IPublicClientApplication>();

        public static SecureString ToSecureString(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return null;
            }
            else
            {
                var result = new SecureString();
                foreach (char c in source.ToCharArray())
                {
                    result.AppendChar(c);
                }

                return result;
            }
        }

        /// <summary>
        ///     Acquires a token interactively
        /// </summary>
        /// <remarks>Acquire a token with possible ui prompts</remarks>
        /// <param name="body">AuthParameters</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid status value</response>
        [HttpPost]
        [Route("/v2/pca/acquireTokenInteractive")]
        [ValidateModelState]
        //[SwaggerOperation("AcquireTokenInteractive")]
        [ProducesResponseType(statusCode: 200, type: typeof(MsalAuthenticationResult))]
        public virtual async Task<IActionResult> AcquireTokenInteractive([FromBody] MsalAuthParameters body)
        {
            string pcaId = body.ClientApplicationId;
            if (string.IsNullOrWhiteSpace(pcaId))
            {
                return BadRequest();
            }

            if (!_pcaMap.TryGetValue(pcaId, out var pca))
            {
                return NotFound();
            }

            try
            {
                var authResult = await pca.AcquireTokenByIntegratedWindowsAuthAsync(body.RequestedScopes.Split(" ").ToList(), body.Username);
                return new ObjectResult(
                    new MsalAuthenticationResult
                    {
                        AccessToken = authResult.AccessToken,
                        ExpiresOn = authResult.ExpiresOn.UtcDateTime,
                        IdToken = authResult.IdToken,
                        Scopes = string.Join(' ', authResult.Scopes)
                    });
            }
            catch (Exception ex) when (ex is MsalServiceException || ex is MsalClientException)
            {
                return new ObjectResult(
                    new MsalAuthenticationResult
                    {
                        IsError = true,
                        AccessToken = ex.Message
                    });
            }

            ////TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            //// return StatusCode(200, default(MsalAuthenticationResult));

            ////TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            //// return StatusCode(400);

            //string exampleJson = null;
            //exampleJson = "{\n  \"isCanceled\" : false,\n  \"isError\" : false,\n  \"idToken\" : \"idToken\",\n  \"errorCode\" : 0,\n  \"expiresOn\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"scopes\" : \"scopes\",\n  \"accessToken\" : \"accessToken\"\n}";

            //var example = exampleJson != null
            //? JsonConvert.DeserializeObject<MsalAuthenticationResult>(exampleJson)
            //: default(MsalAuthenticationResult);
            ////TODO: Change the data returned
            //return new ObjectResult(example);
        }

        /// <summary>
        ///     Acquires a token silently
        /// </summary>
        /// <remarks>Acquire a token with no ui prompts</remarks>
        /// <param name="body">AuthParameters</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid status value</response>
        [HttpPost]
        [Route("/v2/pca/acquireTokenSilent")]
        [ValidateModelState]
        //[SwaggerOperation("AcquireTokenSilent")]
        [ProducesResponseType(statusCode: 200, type: typeof(MsalAuthenticationResult))]
        public virtual IActionResult AcquireTokenSilent([FromBody] MsalAuthParameters body)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(MsalAuthenticationResult));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            string exampleJson = null;
            exampleJson =
                "{\n  \"isCanceled\" : false,\n  \"isError\" : false,\n  \"idToken\" : \"idToken\",\n  \"errorCode\" : 0,\n  \"expiresOn\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"scopes\" : \"scopes\",\n  \"accessToken\" : \"accessToken\"\n}";

            var example = exampleJson != null
                              ? JsonConvert.DeserializeObject<MsalAuthenticationResult>(exampleJson)
                              : default(MsalAuthenticationResult);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        ///     Create a new public client application
        /// </summary>
        /// <param name="body">MsalClientConfiguration object to configure your PCA with</param>
        /// <response code="200">successful operation</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/v2/pca")]
        [ValidateModelState]
        //[SwaggerOperation("CreatePca")]
        [ProducesResponseType(statusCode: 200, type: typeof(CreatePublicClientResult))]
        public virtual IActionResult CreatePca([FromBody] MsalClientConfiguration body)
        {
            var pca = new PublicClientApplication(body.DefaultClientId, body.DefaultAuthority);
            string pcaId = Guid.NewGuid().ToString("N");
            _pcaMap.TryAdd(pcaId, pca);

            return new ObjectResult(
                new CreatePublicClientResult
                {
                    PcaId = pcaId
                });
            ////TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            //// return StatusCode(200, default(CreatePublicClientResult));

            ////TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            //// return StatusCode(405);

            //string exampleJson = null;
            //exampleJson = "{\n  \"pcaId\" : \"pcaId\"\n}";

            //var example = exampleJson != null
            //? JsonConvert.DeserializeObject<CreatePublicClientResult>(exampleJson)
            //: default(CreatePublicClientResult);
            ////TODO: Change the data returned
            //return new ObjectResult(example);
        }

        /// <summary>
        ///     Deletes a PCA
        /// </summary>
        /// <param name="pcaId">PCA id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">PCA not found</response>
        [HttpDelete]
        [Route("/v2/pca/{pcaId}")]
        [ValidateModelState]
        //[SwaggerOperation("DeletePca")]
        public virtual IActionResult DeletePca([FromRoute] [Required] long? pcaId, [FromHeader] string apiKey)
        {
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get MsalClientConfiguration for a particular PCA
        /// </summary>
        /// <remarks>Returns a single MsalClientConfiguration</remarks>
        /// <param name="pcaId">ID of PCA to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">PCA not found</response>
        [HttpGet]
        [Route("/v2/pca/{pcaId}")]
        [ValidateModelState]
        //[SwaggerOperation("GetPcaById")]
        [ProducesResponseType(statusCode: 200, type: typeof(MsalClientConfiguration))]
        public virtual IActionResult GetPcaById([FromRoute] [Required] long? pcaId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(MsalClientConfiguration));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            string exampleJson = null;
            exampleJson = "{\n  \"defaultClientId\" : \"defaultClientId\",\n  \"defaultAuthority\" : \"defaultAuthority\"\n}";

            var example = exampleJson != null
                              ? JsonConvert.DeserializeObject<MsalClientConfiguration>(exampleJson)
                              : default(MsalClientConfiguration);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}