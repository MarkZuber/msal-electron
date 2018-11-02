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
using Microsoft.Identity.MsalApiClient.Api;
using Microsoft.Identity.MsalApiClient.Client;
using Microsoft.Identity.MsalApiClient.Model;

namespace Microsoft.Identity.MsalApiClient.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            Console.WriteLine("Press ENTER to proceed...");
            Console.ReadLine();

            var apiClient = new ApiClient("https://localhost:44346/v2");

            var api = new PublicClientApi(apiClient);
            var config = new MsalClientConfiguration
            {
                DefaultAuthority = "https://login.microsoftonline.com/organizations",
                DefaultClientId = "d3590ed6-52b3-4102-aeff-aad2292ab01c"
            };

            Console.WriteLine("Creating PCA");
            var createResult = api.CreatePca(config);
            Console.WriteLine($"PCA Created: {createResult.PcaId}");

            var authParams = new MsalAuthParameters
            {
                ClientApplicationId = createResult.PcaId,
                AuthorizationType = "Interactive",
                RedirectUri = "https://localhost:5001",
                RequestedScopes = "https://graph.microsoft.com/.default",
                Username = "mzuber@microsoft.com"
            };

            Console.WriteLine($"Calling AcquireToken: {authParams.ToJson()}");
            var authResult = api.AcquireTokenInteractive(authParams);
            Console.WriteLine("Received AuthResult");

            if (authResult.IsError.GetValueOrDefault(false))
            {
                // hack: putting error description in accesstoken since we don't have error codes here...
                Console.WriteLine($"FAILURE: {authResult.AccessToken}");
            }
            else
            {
                Console.WriteLine($"SUCCESS: {authResult.AccessToken}");
            }

            Console.WriteLine(".");
            Console.ReadLine();
        }
    }
}