/*
 * OpenAPI car rent
 *
 * car rent api
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using OpenAPI.Converters;

namespace OpenAPI.Models
{ 
    /// <summary>
    /// A car class class
    /// </summary>
    [DataContract]
    public class CarClass : IEquatable<CarClass>
    {
        /// <summary>
        /// Gets or Sets IdCarClass
        /// </summary>
        [DataMember(Name="idCarClass", EmitDefaultValue=false)]
        public long IdCarClass { get; set; }

        /// <summary>
        /// Gets or Sets _CarClass
        /// </summary>
        [DataMember(Name="carClass", EmitDefaultValue=false)]
        public string _CarClass { get; set; }

        /// <summary>
        /// Gets or Sets Fee
        /// </summary>
        [DataMember(Name="fee", EmitDefaultValue=false)]
        public decimal Fee { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CarClass {\n");
            sb.Append("  IdCarClass: ").Append(IdCarClass).Append("\n");
            sb.Append("  _CarClass: ").Append(_CarClass).Append("\n");
            sb.Append("  Fee: ").Append(Fee).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CarClass)obj);
        }

        /// <summary>
        /// Returns true if CarClass instances are equal
        /// </summary>
        /// <param name="other">Instance of CarClass to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CarClass other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    IdCarClass == other.IdCarClass ||
                    
                    IdCarClass.Equals(other.IdCarClass)
                ) && 
                (
                    _CarClass == other._CarClass ||
                    _CarClass != null &&
                    _CarClass.Equals(other._CarClass)
                ) && 
                (
                    Fee == other.Fee ||
                    
                    Fee.Equals(other.Fee)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    
                    hashCode = hashCode * 59 + IdCarClass.GetHashCode();
                    if (_CarClass != null)
                    hashCode = hashCode * 59 + _CarClass.GetHashCode();
                    
                    hashCode = hashCode * 59 + Fee.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CarClass left, CarClass right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CarClass left, CarClass right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
