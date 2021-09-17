using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Class for route linklist
    /// </summary>
    public sealed class RoutePriceLinkList
    {
        private RoutePriceNode head;
        private RoutePriceNode tail;
        public RoutePriceLinkList()
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
        /// <returns></returns>
        public bool Exists()
        {
            return tail != null;
        }
        /// <summary>
        /// Gets data of route price
        /// </summary>
        /// <returns>Routeprice object</returns>
        public RoutePrice Get()
        {
            return tail.Data;
        }
        /// <summary>
        /// Inserts data into linklist
        /// </summary>
        /// <param name="routePrice">Price of route</param>
        public void InsertData(RoutePrice routePrice)
        {
            var dd = new RoutePriceNode(routePrice, null);
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
        /// Finds price by route name
        /// </summary>
        /// <param name="route">Route</param>
        /// <param name="list">Route's linklist</param>
        /// <returns>Price of route</returns>
        public double FindPriceByRoute(Route route, RouteLinkList list)
        {
            for (RoutePriceNode d = head; d != null; d = d.Link)
            {
                if (d.Data.ArrivalCity == route.ArrivalCity)
                {
                    if (route.DepartureCity == list.CurrentCity)
                    {
                        return d.Data.Price;
                    }
                    else
                    {
                        return d.Data.Price * 0.9;
                    }
                }
            }
            return -1;
        }
    }
}