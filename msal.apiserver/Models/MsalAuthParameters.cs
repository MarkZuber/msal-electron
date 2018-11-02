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

namespace Microsoft.Identity.MsalApiServer.Models
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class MsalAuthParameters : IEquatable<MsalAuthParameters>
    {
        /// <summary>
        ///     Gets or Sets AuthorizationType
        /// </summary>
        public enum AuthorizationTypeEnum
        {
            /// <summary>
            ///     Enum UsernamePasswordEnum for UsernamePassword
            /// </summary>
            [EnumMember(Value = "UsernamePassword")]
            UsernamePasswordEnum = 1,

            /// <summary>
            ///     Enum WindowsIntegratedAuthEnum for WindowsIntegratedAuth
            /// </summary>
            [EnumMember(Value = "WindowsIntegratedAuth")]
            WindowsIntegratedAuthEnum = 2,

            /// <summary>
            ///     Enum AuthCodeEnum for AuthCode
            /// </summary>
            [EnumMember(Value = "AuthCode")]
            AuthCodeEnum = 3,

            /// <summary>
            ///     Enum InteractiveEnum for Interactive
            /// </summary>
            [EnumMember(Value = "Interactive")]
            InteractiveEnum = 4,

            /// <summary>
            ///     Enum CertificateEnum for Certificate
            /// </summary>
            [EnumMember(Value = "Certificate")]
            CertificateEnum = 5
        }

        /// <summary>
        ///     Gets or Sets ClientApplicationId
        /// </summary>
        [DataMember(Name = "clientApplicationId")]
        public string ClientApplicationId { get; set; }

        /// <summary>
        ///     Gets or Sets ClientId
        /// </summary>
        [DataMember(Name = "clientId")]
        public string ClientId { get; set; }

        /// <summary>
        ///     Gets or Sets Authority
        /// </summary>
        [DataMember(Name = "authority")]
        public string Authority { get; set; }

        /// <summary>
        ///     Gets or Sets RedirectUri
        /// </summary>
        [DataMember(Name = "redirectUri")]
        public string RedirectUri { get; set; }

        /// <summary>
        ///     Gets or Sets RequestedScopes
        /// </summary>
        [DataMember(Name = "requestedScopes")]
        public string RequestedScopes { get; set; }

        /// <summary>
        ///     Gets or Sets Username
        /// </summary>
        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        ///     Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or Sets TelemetryCorrelationId
        /// </summary>
        [DataMember(Name = "telemetryCorrelationId")]
        public string TelemetryCorrelationId { get; set; }

        /// <summary>
        ///     Gets or Sets AuthorizationType
        /// </summary>
        [DataMember(Name = "authorizationType")]
        public AuthorizationTypeEnum? AuthorizationType { get; set; }

        /// <summary>
        ///     Returns true if MsalAuthParameters instances are equal
        /// </summary>
        /// <param name="other">Instance of MsalAuthParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MsalAuthParameters other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return
                (ClientApplicationId == other.ClientApplicationId ||
                 ClientApplicationId != null && ClientApplicationId.Equals(other.ClientApplicationId)) &&
                (ClientId == other.ClientId || ClientId != null && ClientId.Equals(other.ClientId)) &&
                (Authority == other.Authority || Authority != null && Authority.Equals(other.Authority)) &&
                (RedirectUri == other.RedirectUri || RedirectUri != null && RedirectUri.Equals(other.RedirectUri)) &&
                (RequestedScopes == other.RequestedScopes ||
                 RequestedScopes != null && RequestedScopes.Equals(other.RequestedScopes)) &&
                (Username == other.Username || Username != null && Username.Equals(other.Username)) &&
                (Password == other.Password || Password != null && Password.Equals(other.Password)) &&
                (TelemetryCorrelationId == other.TelemetryCorrelationId || TelemetryCorrelationId != null &&
                 TelemetryCorrelationId.Equals(other.TelemetryCorrelationId)) &&
                (AuthorizationType == other.AuthorizationType ||
                 AuthorizationType != null && AuthorizationType.Equals(other.AuthorizationType));
        }

        /// <summary>
        ///     Returns the string presentation of the object
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
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((MsalAuthParameters)obj);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (ClientApplicationId != null)
                {
                    hashCode = hashCode * 59 + ClientApplicationId.GetHashCode();
                }

                if (ClientId != null)
                {
                    hashCode = hashCode * 59 + ClientId.GetHashCode();
                }

                if (Authority != null)
                {
                    hashCode = hashCode * 59 + Authority.GetHashCode();
                }

                if (RedirectUri != null)
                {
                    hashCode = hashCode * 59 + RedirectUri.GetHashCode();
                }

                if (RequestedScopes != null)
                {
                    hashCode = hashCode * 59 + RequestedScopes.GetHashCode();
                }

                if (Username != null)
                {
                    hashCode = hashCode * 59 + Username.GetHashCode();
                }

                if (Password != null)
                {
                    hashCode = hashCode * 59 + Password.GetHashCode();
                }

                if (TelemetryCorrelationId != null)
                {
                    hashCode = hashCode * 59 + TelemetryCorrelationId.GetHashCode();
                }

                if (AuthorizationType != null)
                {
                    hashCode = hashCode * 59 + AuthorizationType.GetHashCode();
                }

                return hashCode;
            }
        }

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(MsalAuthParameters left, MsalAuthParameters right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MsalAuthParameters left, MsalAuthParameters right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}