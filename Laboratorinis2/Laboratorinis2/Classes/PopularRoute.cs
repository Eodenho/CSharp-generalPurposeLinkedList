using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Popular routes class
    /// </summary>
    public sealed class PopularRoute
    {
        public string DepartureCity { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int Day { get; set; }
        public PopularRoute(string departurecity, TimeSpan departuretime, TimeSpan arrivaltime, int day)
        {
            this.DepartureCity = departurecity;
            this.DepartureTime = departuretime;
            this.ArrivalTime = arrivaltime;
            this.Day = day;
        }
        /// <summary>
        /// Overrides ToString method
        /// </summary>
        /// <returns>Formatted string</returns>
        public override string ToString()
        {
            return String.Format("| {0,-18} | {1,-16} | {2,-17} | {3,-10} |", this.DepartureCity, this.DepartureTime, this.ArrivalTime, this.Day);
        }
        /// <summary>
        /// Overrides equals method
        /// </summary>
        /// <param name="obj">Object that is being checked</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            return obj is PopularRoute route &&
                   DepartureCity == route.DepartureCity &&
                   DepartureTime.Equals(route.DepartureTime) &&
                   ArrivalTime.Equals(route.ArrivalTime) &&
                   Day == route.Day;
        }
        /// <summary>
        /// Returns hashcode
        /// </summary>
        /// <returns>Hashcode</returns>
        public override int GetHashCode()
        {
            int hashCode = 458600070;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DepartureCity);
            hashCode = hashCode * -1521134295 + DepartureTime.GetHashCode();
            hashCode = hashCode * -1521134295 + ArrivalTime.GetHashCode();
            hashCode = hashCode * -1521134295 + Day.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// Compares popular routes by departure city and departure time
        /// </summary>
        /// <param name="lhs">Popular route one</param>
        /// <param name="rhs">Popular route two</param>
        /// <returns>True or false</returns>
        public static bool operator <(PopularRoute lhs, PopularRoute rhs)
        {
            return lhs.DepartureCity.CompareTo(rhs.DepartureCity) < 0 || lhs.DepartureCity.CompareTo(rhs.DepartureCity) == 0 && lhs.DepartureTime.CompareTo(rhs.DepartureTime) < 0;
        }
        /// <summary>
        /// Compares popular routes by departure city and departure time
        /// </summary>
        /// <param name="lhs">Popular route one</param>
        /// <param name="rhs">Popular route two</param>
        /// <returns>True or false</returns>
        public static bool operator >(PopularRoute lhs, PopularRoute rhs)
        {
            return lhs.DepartureCity.CompareTo(rhs.DepartureCity) > 0 || lhs.DepartureCity.CompareTo(rhs.DepartureCity) == 0 && lhs.DepartureTime.CompareTo(rhs.DepartureTime) > 0;
        }
    }
}