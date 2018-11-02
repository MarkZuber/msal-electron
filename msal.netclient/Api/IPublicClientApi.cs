using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Identity.MsalApiClient.Model;

namespace Microsoft.Identity.MsalApiClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IPublicClientApi
    {
        /// <summary>
        /// Acquires a token interactively Acquire a token with possible ui prompts
        /// </summary>
        /// <param name="body">AuthParameters</param>
        /// <returns>MsalAuthenticationResult</returns>
        MsalAuthenticationResult AcquireTokenInteractive(MsalAuthParameters body);

        /// <summary>
        /// Acquires a token silently Acquire a token with no ui prompts
        /// </summary>
        /// <param name="body">AuthParameters</param>
        /// <returns>MsalAuthenticationResult</returns>
        MsalAuthenticationResult AcquireTokenSilent(MsalAuthParameters body);

        /// <summary>
        /// Create a new public client application 
        /// </summary>
        /// <param name="body">MsalClientConfiguration object to configure your PCA with</param>
        /// <returns>CreatePublicClientResult</returns>
        CreatePublicClientResult CreatePca(MsalClientConfiguration body);

        /// <summary>
        /// Deletes a PCA 
        /// </summary>
        /// <param name="pcaId">PCA id to delete</param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        void DeletePca(long? pcaId, string apiKey);

        /// <summary>
        /// Get MsalClientConfiguration for a particular PCA Returns a single MsalClientConfiguration
        /// </summary>
        /// <param name="pcaId">ID of PCA to return</param>
        /// <returns>MsalClientConfiguration</returns>
        MsalClientConfiguration GetPcaById(long? pcaId);
    }
}
