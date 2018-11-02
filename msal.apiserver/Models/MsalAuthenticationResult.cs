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
    public class MsalAuthenticationResult : IEquatable<MsalAuthenticationResult>
    {
        /// <summary>
        ///     Gets or Sets IsCanceled
        /// </summary>
        [DataMember(Name = "isCanceled")]
        public bool? IsCanceled { get; set; }

        /// <summary>
        ///     Gets or Sets IsError
        /// </summary>
        [DataMember(Name = "isError")]
        public bool? IsError { get; set; }

        /// <summary>
        ///     Gets or Sets ErrorCode
        /// </summary>
        [DataMember(Name = "errorCode")]
        public long? ErrorCode { get; set; }

        /// <summary>
        ///     Gets or Sets AccessToken
        /// </summary>
        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or Sets IdToken
        /// </summary>
        [DataMember(Name = "idToken")]
        public string IdToken { get; set; }

        /// <summary>
        ///     Gets or Sets Scopes
        /// </summary>
        [DataMember(Name = "scopes")]
        public string Scopes { get; set; }

        /// <summary>
        ///     Gets or Sets ExpiresOn
        /// </summary>
        [DataMember(Name = "expiresOn")]
        public DateTime? ExpiresOn { get; set; }

        /// <summary>
        ///     Returns true if MsalAuthenticationResult instances are equal
        /// </summary>
        /// <param name="other">Instance of MsalAuthenticationResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MsalAuthenticationResult other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return (IsCanceled == other.IsCanceled || IsCanceled != null && IsCanceled.Equals(other.IsCanceled)) &&
                   (IsError == other.IsError || IsError != null && IsError.Equals(other.IsError)) &&
                   (ErrorCode == other.ErrorCode || ErrorCode != null && ErrorCode.Equals(other.ErrorCode)) &&
                   (AccessToken == other.AccessToken || AccessToken != null && AccessToken.Equals(other.AccessToken)) &&
                   (IdToken == other.IdToken || IdToken != null && IdToken.Equals(other.IdToken)) &&
                   (Scopes == other.Scopes || Scopes != null && Scopes.Equals(other.Scopes)) &&
                   (ExpiresOn == other.ExpiresOn || ExpiresOn != null && ExpiresOn.Equals(other.ExpiresOn));
        }

        /// <summary>
        ///     Returns the string presentation of the object
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

            return obj.GetType() == GetType() && Equals((MsalAuthenticationResult)obj);
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
                if (IsCanceled != null)
                {
                    hashCode = hashCode * 59 + IsCanceled.GetHashCode();
                }

                if (IsError != null)
                {
                    hashCode = hashCode * 59 + IsError.GetHashCode();
                }

                if (ErrorCode != null)
                {
                    hashCode = hashCode * 59 + ErrorCode.GetHashCode();
                }

                if (AccessToken != null)
                {
                    hashCode = hashCode * 59 + AccessToken.GetHashCode();
                }

                if (IdToken != null)
                {
                    hashCode = hashCode * 59 + IdToken.GetHashCode();
                }

                if (Scopes != null)
                {
                    hashCode = hashCode * 59 + Scopes.GetHashCode();
                }

                if (ExpiresOn != null)
                {
                    hashCode = hashCode * 59 + ExpiresOn.GetHashCode();
                }

                return hashCode;
            }
        }

        #region Operators

#pragma warning disable 1591

        public static bool operator ==(MsalAuthenticationResult left, MsalAuthenticationResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MsalAuthenticationResult left, MsalAuthenticationResult right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591

        #endregion Operators
    }
}