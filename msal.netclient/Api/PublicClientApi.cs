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

using System.Collections.Generic;
using Microsoft.Identity.MsalApiClient.Client;
using Microsoft.Identity.MsalApiClient.Model;
using RestSharp;

namespace Microsoft.Identity.MsalApiClient.Api
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PublicClientApi : IPublicClientApi
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PcaApi" /> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public PublicClientApi(ApiClient apiClient = null)
        {
            ApiClient = apiClient ?? Configuration.DefaultApiClient;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PcaApi" /> class.
        /// </summary>
        /// <returns></returns>
        public PublicClientApi(string basePath)
        {
            ApiClient = new ApiClient(basePath);
        }

        /// <summary>
        ///     Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        ///     Acquires a token interactively Acquire a token with possible ui prompts
        /// </summary>
        /// <param name="body">AuthParameters</param>
        /// <returns>MsalAuthenticationResult</returns>
        public MsalAuthenticationResult AcquireTokenInteractive(MsalAuthParameters body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ApiException(400, "Missing required parameter 'body' when calling AcquireTokenInteractive");
            }

            string path = "/pca/acquireTokenInteractive";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<string, string>();
            var headerParams = new Dictionary<string, string>();
            var formParams = new Dictionary<string, string>();
            var fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            var authSettings = new string[]
            {
                "msal_auth"
            };

            // make the HTTP request
            var response = (IRestResponse)ApiClient.CallApi(
                path,
                Method.POST,
                queryParams,
                postBody,
                headerParams,
                formParams,
                fileParams,
                authSettings);

            if ((int)response.StatusCode >= 400)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling AcquireTokenInteractive: " + response.Content,
                    response.Content);
            }
            else if ((int)response.StatusCode == 0)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling AcquireTokenInteractive: " + response.ErrorMessage,
                    response.ErrorMessage);
            }

            return (MsalAuthenticationResult)ApiClient.Deserialize(
                response.Content,
                typeof(MsalAuthenticationResult),
                response.Headers);
        }

        /// <summary>
        ///     Acquires a token silently Acquire a token with no ui prompts
        /// </summary>
        /// <param name="body">AuthParameters</param>
        /// <returns>MsalAuthenticationResult</returns>
        public MsalAuthenticationResult AcquireTokenSilent(MsalAuthParameters body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ApiException(400, "Missing required parameter 'body' when calling AcquireTokenSilent");
            }

            string path = "/pca/acquireTokenSilent";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<string, string>();
            var headerParams = new Dictionary<string, string>();
            var formParams = new Dictionary<string, string>();
            var fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            var authSettings = new string[]
            {
                "msal_auth"
            };

            // make the HTTP request
            var response = (IRestResponse)ApiClient.CallApi(
                path,
                Method.POST,
                queryParams,
                postBody,
                headerParams,
                formParams,
                fileParams,
                authSettings);

            if ((int)response.StatusCode >= 400)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling AcquireTokenSilent: " + response.Content,
                    response.Content);
            }
            else if ((int)response.StatusCode == 0)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling AcquireTokenSilent: " + response.ErrorMessage,
                    response.ErrorMessage);
            }

            return (MsalAuthenticationResult)ApiClient.Deserialize(
                response.Content,
                typeof(MsalAuthenticationResult),
                response.Headers);
        }

        /// <summary>
        ///     Create a new public client application
        /// </summary>
        /// <param name="body">MsalClientConfiguration object to configure your PCA with</param>
        /// <returns>CreatePublicClientResult</returns>
        public CreatePublicClientResult CreatePca(MsalClientConfiguration body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ApiException(400, "Missing required parameter 'body' when calling CreatePca");
            }

            string path = "/pca";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<string, string>();
            var headerParams = new Dictionary<string, string>();
            var formParams = new Dictionary<string, string>();
            var fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            var authSettings = new string[]
            {
                "msal_auth"
            };

            // make the HTTP request
            var response = (IRestResponse)ApiClient.CallApi(
                path,
                Method.POST,
                queryParams,
                postBody,
                headerParams,
                formParams,
                fileParams,
                authSettings);

            if ((int)response.StatusCode >= 400)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling CreatePca: " + response.Content,
                    response.Content);
            }
            else if ((int)response.StatusCode == 0)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling CreatePca: " + response.ErrorMessage,
                    response.ErrorMessage);
            }

            return (CreatePublicClientResult)ApiClient.Deserialize(
                response.Content,
                typeof(CreatePublicClientResult),
                response.Headers);
        }

        /// <summary>
        ///     Deletes a PCA
        /// </summary>
        /// <param name="pcaId">PCA id to delete</param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public void DeletePca(long? pcaId, string apiKey)
        {
            // verify the required parameter 'pcaId' is set
            if (pcaId == null)
            {
                throw new ApiException(400, "Missing required parameter 'pcaId' when calling DeletePca");
            }

            string path = "/pca/{pcaId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "pcaId" + "}", ApiClient.ParameterToString(pcaId));

            var queryParams = new Dictionary<string, string>();
            var headerParams = new Dictionary<string, string>();
            var formParams = new Dictionary<string, string>();
            var fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (apiKey != null)
            {
                headerParams.Add("api_key", ApiClient.ParameterToString(apiKey)); // header parameter
            }

            // authentication setting, if any
            var authSettings = new string[]
            {
                "msal_auth"
            };

            // make the HTTP request
            var response = (IRestResponse)ApiClient.CallApi(
                path,
                Method.DELETE,
                queryParams,
                postBody,
                headerParams,
                formParams,
                fileParams,
                authSettings);

            if ((int)response.StatusCode >= 400)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling DeletePca: " + response.Content,
                    response.Content);
            }
            else if ((int)response.StatusCode == 0)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling DeletePca: " + response.ErrorMessage,
                    response.ErrorMessage);
            }

            return;
        }

        /// <summary>
        ///     Get MsalClientConfiguration for a particular PCA Returns a single MsalClientConfiguration
        /// </summary>
        /// <param name="pcaId">ID of PCA to return</param>
        /// <returns>MsalClientConfiguration</returns>
        public MsalClientConfiguration GetPcaById(long? pcaId)
        {
            // verify the required parameter 'pcaId' is set
            if (pcaId == null)
            {
                throw new ApiException(400, "Missing required parameter 'pcaId' when calling GetPcaById");
            }

            string path = "/pca/{pcaId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "pcaId" + "}", ApiClient.ParameterToString(pcaId));

            var queryParams = new Dictionary<string, string>();
            var headerParams = new Dictionary<string, string>();
            var formParams = new Dictionary<string, string>();
            var fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            var authSettings = new string[]
            {
                "api_key"
            };

            // make the HTTP request
            var response = (IRestResponse)ApiClient.CallApi(
                path,
                Method.GET,
                queryParams,
                postBody,
                headerParams,
                formParams,
                fileParams,
                authSettings);

            if ((int)response.StatusCode >= 400)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling GetPcaById: " + response.Content,
                    response.Content);
            }
            else if ((int)response.StatusCode == 0)
            {
                throw new ApiException(
                    (int)response.StatusCode,
                    "Error calling GetPcaById: " + response.ErrorMessage,
                    response.ErrorMessage);
            }

            return (MsalClientConfiguration)ApiClient.Deserialize(
                response.Content,
                typeof(MsalClientConfiguration),
                response.Headers);
        }

        /// <summary>
        ///     Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(string basePath)
        {
            ApiClient.BasePath = basePath;
        }

        /// <summary>
        ///     Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public string GetBasePath(string basePath)
        {
            return ApiClient.BasePath;
        }
    }
}