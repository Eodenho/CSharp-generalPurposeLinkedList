using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Class for route prices
    /// </summary>
    public class RoutePrice
    {
        public string ArrivalCity { get; set; }
        public double Price { get; set; }
        public RoutePrice(string arrivalcity, double price)
        {
            this.ArrivalCity = arrivalcity;
            this.Price = price;
        }
        /// <summary>
        /// Overrides ToString method
        /// </summary>
        /// <returns>Formatted string</returns>
        public override string ToString()
        {
            return String.Format("| {0,-16} | {1,-7} |", this.ArrivalCity, this.Price);
        }
    }
}