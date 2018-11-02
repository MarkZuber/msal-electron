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
using System.Threading.Tasks;
using Microsoft.Identity.MsalApiClient.Api;
using Microsoft.Identity.MsalApiClient.Client;
using Microsoft.Identity.MsalApiClient.Model;

namespace Microsoft.Identity.MsalApiClient
{
    public class PublicClientApplicationProxy
    {
        private readonly PublicClientApi _publicClientApi;
        private readonly string _publicClientApiId;

        public PublicClientApplicationProxy(
            string defaultClientId,
            string defaultAuthority,
            string endpointUrl = "https://localhost:44346/v2")
        {
            _publicClientApi = new PublicClientApi(new ApiClient(endpointUrl));
            var config = new MsalClientConfiguration
            {
                DefaultAuthority = defaultAuthority,
                DefaultClientId = defaultClientId
            };

            var createResult = _publicClientApi.CreatePca(config);
            _publicClientApiId = createResult.PcaId;
        }

        public async Task<MsalAuthenticationResult> AcquireTokenByInteractiveWindowsAuthAsync(string redirectUri, IEnumerable<string> requestedScopes, string username)
        {
            var authParams = new MsalAuthParameters
            {
                ClientApplicationId = _publicClientApiId,
                AuthorizationType = "Interactive",
                RedirectUri = redirectUri,
                RequestedScopes = string.Join(" ", requestedScopes),
                Username = username
            };

            return await Task.Run(() => _publicClientApi.AcquireTokenInteractive(authParams));
        }
    }
}