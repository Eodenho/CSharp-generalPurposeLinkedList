using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Class for route linklist
    /// </summary>
    public sealed class RouteLinkList
    {
        public string CurrentCity { get; set; }
        private RouteNode head;
        private RouteNode tail;
        public RouteLinkList()
        {
            this.head = null;
            this.tail = null;
        }
        /// <summary>
        /// Initializes a linklist
        /// </summary>
        public void Head()
        {
            tail = head;
        }
        /// <summary>
        /// Moves linklist
        /// </summary>
        public void Link()
        {
            tail = tail.Link;
        }
        /// <summary>
        /// Checks if node exists
        /// </summary>
        /// <returns>True or false</returns>
        public bool Exists()
        {
            return tail != null;
        }
        /// <summary>
        /// Returns route data
        /// </summary>
        /// <returns>Route</returns>
        public Route Get()
        {
            return tail.Data;
        }
        /// <summary>
        /// Inserts data into linklist
        /// </summary>
        /// <param name="busRoute">Route</param>
        public void InsertData(Route busRoute)
        {
            var dd = new RouteNode(busRoute, null);
            if (head != null)
            {
                tail.Link = dd;
                tail = dd;
            }
            else
            {
                head = dd;
                tail = dd;
            }
        }
        /// <summary>
        /// Destroys the whole linklist
        /// </summary>
        public void Destroy()
        {
            while (head != null)
            {
                tail = head;
                head = head.Link;
                tail.Link = null;
            }
        }
        /// <summary>
        /// Finds all possible routes by time city and day
        /// </summary>
        /// <param name="day">Day of travelling</param>
        /// <param name="arrival">City of arrival</param>
        /// <param name="start">Latest time for arrival</param>
        /// <param name="finish">Earliest time for departure</param>
        /// <returns>Possible routes to travel</returns>
        public RouteLinkList CanTravel(int day, string arrival, TimeSpan start, TimeSpan finish)
        {
            RouteLinkList possibleroutes = new RouteLinkList();
            for (RouteNode d = head; d != null; d = d.Link)
            {
                if (d.Data.Day == day && d.Data.ArrivalCity == arrival && d.Data.DepartureTime >= start && d.Data.ArrivalTime <= finish)
                {
                    possibleroutes.InsertData(d.Data);
                }
            }
            possibleroutes.CurrentCity = this.CurrentCity;
            return possibleroutes;
        }
        /// <summary>
        /// Finds linklist of cheapest routes
        /// </summary>
        /// <param name="possibleTravels">All posible routes</param>
        /// <returns>Cheapest routes</returns>
        public RouteLinkList CheapestRoutes(RouteLinkList possibleTravels)
        {
            RouteLinkList cheapestTravels = new RouteLinkList();
            for (RouteNode d = head; d != null; d = d.Link)
            {
                if (d.Data.DepartureCity != this.CurrentCity)
                {
                    cheapestTravels.InsertData(d.Data);
                }
            }
            if (cheapestTravels.head == null)
            {
                return possibleTravels;
            }
            else
            {
                return cheapestTravels;
            }
        }
        /// <summary>
        /// Finds cheapest route price
        /// </summary>
        /// <param name="cheapestRoutes">Linklist of cheapest routes</param>
        /// <param name="prices">Linklist of route prices</param>
        /// <returns>Cheapest price</returns>
        public double CheapestRoutesPrice(RouteLinkList cheapestRoutes, RoutePriceLinkList prices)
        {
            return prices.FindPriceByRoute(cheapestRoutes.head.Data, cheapestRoutes);
        }
        /// <summary>
        /// Finds most popular route
        /// </summary>
        /// <returns>Most popular city of arrival</returns>
        public string FindMostPopularRoute()
        {
            RouteNode d = head;
            int max = -1;
            string res = "";
            while (d != null)
            {
                RouteNode s = d.Link;
                int count = 1;

                while (s != null)
                {
                    if (d.Data.ArrivalCity == s.Data.ArrivalCity)
                        count++;
                    s = s.Link;
                }
                if (max < count)
                {
                    res = d.Data.ArrivalCity;
                    max = count;
                }
                d = d.Link;
            }
            return res;
        }
        /// <summary>
        /// Finds most popular routes
        /// </summary>
        /// <returns>Popular routes linklist</returns>
        public PopularRouteLinkList PopularRoutes()
        {
            PopularRouteLinkList list = new PopularRouteLinkList();
            for (RouteNode d = head; d != null; d = d.Link)
            {
                if (d.Data.ArrivalCity == FindMostPopularRoute())
                {
                    PopularRoute route = new PopularRoute(d.Data.DepartureCity, d.Data.DepartureTime, d.Data.ArrivalTime, d.Data.Day);
                    list.InsertData(route);
                }
            }
            return list;
        }
    }
}