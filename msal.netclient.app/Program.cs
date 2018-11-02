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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Identity.MsalApiClient.App
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Starting...");
            Console.WriteLine("Press ENTER to proceed...");
            Console.ReadLine();

            var pca = new PublicClientApplicationProxy(
                "d3590ed6-52b3-4102-aeff-aad2292ab01c",
                "https://login.microsoftonline.com/organizations");

            var authResult = await pca.AcquireTokenByInteractiveWindowsAuthAsync(
                                 "https://localhost:5001",
                                 new List<string>
                                 {
                                     "https://graph.microsoft.com/.default"
                                 },
                                 "mzuber@microsoft.com");

            Console.WriteLine(
                authResult.IsError.GetValueOrDefault(false)
                    ? $"FAILURE: {authResult.AccessToken}"
                    : $"SUCCESS: {authResult.AccessToken}");

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}