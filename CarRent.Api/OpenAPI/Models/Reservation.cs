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
    /// A reservation
    /// </summary>
    [DataContract]
    public class Reservation : IEquatable<Reservation>
    {
        /// <summary>
        /// Gets or Sets IdReservation
        /// </summary>
        [DataMember(Name="idReservation", EmitDefaultValue=false)]
        public long IdReservation { get; set; }

        /// <summary>
        /// Gets or Sets Car
        /// </summary>
        [DataMember(Name="car", EmitDefaultValue=false)]
        public Car Car { get; set; }

        /// <summary>
        /// Gets or Sets Days
        /// </summary>
        [DataMember(Name="days", EmitDefaultValue=false)]
        public int Days { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or Sets ReservationNr
        /// </summary>
        [DataMember(Name="reservationNr", EmitDefaultValue=false)]
        public string ReservationNr { get; set; }

        /// <summary>
        /// Gets or Sets PickUpDate
        /// </summary>
        [DataMember(Name="pickUpDate", EmitDefaultValue=false)]
        public DateTime PickUpDate { get; set; }

        /// <summary>
        /// Gets or Sets IsLease
        /// </summary>
        [DataMember(Name="isLease", EmitDefaultValue=false)]
        public bool IsLease { get; set; }

        /// <summary>
        /// Gets or Sets Customer
        /// </summary>
        [DataMember(Name="customer", EmitDefaultValue=false)]
        public Customer Customer { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Reservation {\n");
            sb.Append("  IdReservation: ").Append(IdReservation).Append("\n");
            sb.Append("  Car: ").Append(Car).Append("\n");
            sb.Append("  Days: ").Append(Days).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  ReservationNr: ").Append(ReservationNr).Append("\n");
            sb.Append("  PickUpDate: ").Append(PickUpDate).Append("\n");
            sb.Append("  IsLease: ").Append(IsLease).Append("\n");
            sb.Append("  Customer: ").Append(Customer).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Reservation)obj);
        }

        /// <summary>
        /// Returns true if Reservation instances are equal
        /// </summary>
        /// <param name="other">Instance of Reservation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Reservation other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    IdReservation == other.IdReservation ||
                    
                    IdReservation.Equals(other.IdReservation)
                ) && 
                (
                    Car == other.Car ||
                    Car != null &&
                    Car.Equals(other.Car)
                ) && 
                (
                    Days == other.Days ||
                    
                    Days.Equals(other.Days)
                ) && 
                (
                    Price == other.Price ||
                    
                    Price.Equals(other.Price)
                ) && 
                (
                    ReservationNr == other.ReservationNr ||
                    ReservationNr != null &&
                    ReservationNr.Equals(other.ReservationNr)
                ) && 
                (
                    PickUpDate == other.PickUpDate ||
                    PickUpDate != null &&
                    PickUpDate.Equals(other.PickUpDate)
                ) && 
                (
                    IsLease == other.IsLease ||
                    
                    IsLease.Equals(other.IsLease)
                ) && 
                (
                    Customer == other.Customer ||
                    Customer != null &&
                    Customer.Equals(other.Customer)
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
                    
                    hashCode = hashCode * 59 + IdReservation.GetHashCode();
                    if (Car != null)
                    hashCode = hashCode * 59 + Car.GetHashCode();
                    
                    hashCode = hashCode * 59 + Days.GetHashCode();
                    
                    hashCode = hashCode * 59 + Price.GetHashCode();
                    if (ReservationNr != null)
                    hashCode = hashCode * 59 + ReservationNr.GetHashCode();
                    if (PickUpDate != null)
                    hashCode = hashCode * 59 + PickUpDate.GetHashCode();
                    
                    hashCode = hashCode * 59 + IsLease.GetHashCode();
                    if (Customer != null)
                    hashCode = hashCode * 59 + Customer.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Reservation left, Reservation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Reservation left, Reservation right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
