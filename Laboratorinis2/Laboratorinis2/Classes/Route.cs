using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Class for routes
    /// </summary>
    public class Route
    {
        public string DepartureCity { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string ArrivalCity { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int Day { get; set; }
        public Route(string departurecity, TimeSpan departuretime, string arrivalcity, TimeSpan arrivaltime, int day)
        {
            this.DepartureCity = departurecity;
            this.DepartureTime = departuretime;
            this.ArrivalCity = arrivalcity;
            this.ArrivalTime = arrivaltime;
            this.Day = day;
        }
        /// <summary>
        /// Overrides ToString method
        /// </summary>
        /// <returns>Formatted string</returns>
        public override string ToString()
        {
            return String.Format("| {0,-18} | {1,-16} | {2,-18} | {3,-17} | {4,-10} |", this.DepartureCity, this.DepartureTime, this.ArrivalCity, this.ArrivalTime, this.Day);
        }
        /// <summary>
        /// Overrides equals method
        /// </summary>
        /// <param name="obj">Object that is being compared</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            return obj is Route route &&
                   DepartureTime.Equals(route.DepartureTime) &&
                   ArrivalCity == route.ArrivalCity &&
                   ArrivalTime.Equals(route.ArrivalTime) &&
                   Day == route.Day;
        }
        /// <summary>
        /// Returns hashcode
        /// </summary>
        /// <returns>Hashcode</returns>
        public override int GetHashCode()
        {
            int hashCode = 1015068907;
            hashCode = hashCode * -1521134295 + DepartureTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ArrivalCity);
            hashCode = hashCode * -1521134295 + ArrivalTime.GetHashCode();
            hashCode = hashCode * -1521134295 + Day.GetHashCode();
            return hashCode;
        }
    }
}