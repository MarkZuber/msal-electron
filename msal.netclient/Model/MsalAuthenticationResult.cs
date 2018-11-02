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
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Microsoft.Identity.MsalApiClient.Model
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class MsalAuthenticationResult
    {
        /// <summary>
        ///     Gets or Sets IsCanceled
        /// </summary>
        [DataMember(Name = "isCanceled", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isCanceled")]
        public bool? IsCanceled { get; set; }

        /// <summary>
        ///     Gets or Sets IsError
        /// </summary>
        [DataMember(Name = "isError", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isError")]
        public bool? IsError { get; set; }

        /// <summary>
        ///     Gets or Sets ErrorCode
        /// </summary>
        [DataMember(Name = "errorCode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "errorCode")]
        public long? ErrorCode { get; set; }

        /// <summary>
        ///     Gets or Sets AccessToken
        /// </summary>
        [DataMember(Name = "accessToken", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or Sets IdToken
        /// </summary>
        [DataMember(Name = "idToken", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "idToken")]
        public string IdToken { get; set; }

        /// <summary>
        ///     Gets or Sets Scopes
        /// </summary>
        [DataMember(Name = "scopes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scopes")]
        public string Scopes { get; set; }

        /// <summary>
        ///     Gets or Sets ExpiresOn
        /// </summary>
        [DataMember(Name = "expiresOn", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "expiresOn")]
        public DateTime? ExpiresOn { get; set; }

        /// <summary>
        ///     Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MsalAuthenticationResult {\n");
            sb.Append("  IsCanceled: ").Append(IsCanceled).Append("\n");
            sb.Append("  IsError: ").Append(IsError).Append("\n");
            sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
            sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
            sb.Append("  IdToken: ").Append(IdToken).Append("\n");
            sb.Append("  Scopes: ").Append(Scopes).Append("\n");
            sb.Append("  ExpiresOn: ").Append(ExpiresOn).Append("\n");
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