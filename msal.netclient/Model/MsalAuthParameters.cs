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

using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Microsoft.Identity.MsalApiClient.Model
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class MsalAuthParameters
    {
        /// <summary>
        ///     Gets or Sets ClientApplicationId
        /// </summary>
        [DataMember(Name = "clientApplicationId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "clientApplicationId")]
        public string ClientApplicationId { get; set; }

        /// <summary>
        ///     Gets or Sets ClientId
        /// </summary>
        [DataMember(Name = "clientId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

        /// <summary>
        ///     Gets or Sets Authority
        /// </summary>
        [DataMember(Name = "authority", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "authority")]
        public string Authority { get; set; }

        /// <summary>
        ///     Gets or Sets RedirectUri
        /// </summary>
        [DataMember(Name = "redirectUri", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "redirectUri")]
        public string RedirectUri { get; set; }

        /// <summary>
        ///     Gets or Sets RequestedScopes
        /// </summary>
        [DataMember(Name = "requestedScopes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "requestedScopes")]
        public string RequestedScopes { get; set; }

        /// <summary>
        ///     Gets or Sets Username
        /// </summary>
        [DataMember(Name = "username", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        ///     Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or Sets TelemetryCorrelationId
        /// </summary>
        [DataMember(Name = "telemetryCorrelationId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "telemetryCorrelationId")]
        public string TelemetryCorrelationId { get; set; }

        /// <summary>
        ///     Gets or Sets AuthorizationType
        /// </summary>
        [DataMember(Name = "authorizationType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "authorizationType")]
        public string AuthorizationType { get; set; }

        /// <summary>
        ///     Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MsalAuthParameters {\n");
            sb.Append("  ClientApplicationId: ").Append(ClientApplicationId).Append("\n");
            sb.Append("  ClientId: ").Append(ClientId).Append("\n");
            sb.Append("  Authority: ").Append(Authority).Append("\n");
            sb.Append("  RedirectUri: ").Append(RedirectUri).Append("\n");
            sb.Append("  RequestedScopes: ").Append(RequestedScopes).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  TelemetryCorrelationId: ").Append(TelemetryCorrelationId).Append("\n");
            sb.Append("  AuthorizationType: ").Append(AuthorizationType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}