using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Class for popular routes
    /// </summary>
    public sealed class PopularRouteLinkList
    {
        private PopularRouteNode head;
        private PopularRouteNode tail;
        public PopularRouteLinkList()
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
        /// Gets data of popular route
        /// </summary>
        /// <returns>Popular route data</returns>
        public PopularRoute Get()
        {
            return tail.Data;
        }
        /// <summary>
        /// Inserts data into popular route linklist
        /// </summary>
        /// <param name="busRoute">Popular route</param>
        public void InsertData(PopularRoute busRoute)
        {
            var dd = new PopularRouteNode(busRoute, null);
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
        /// Sorts the popular route linklist
        /// </summary>
        public void Sort()
        {
            for (PopularRouteNode d1 = head; d1 != null; d1 = d1.Link)
            {
                PopularRouteNode minValue = d1;
                for (PopularRouteNode d2 = d1; d2 != null; d2 = d2.Link)
                {
                    if (d2.Data < minValue.Data)
                    {
                        minValue = d2;
                    }
                }
                PopularRoute temp = d1.Data;
                d1.Data = minValue.Data;
                minValue.Data = temp;
            }
        }
        /// <summary>
        /// Removes transit buses and puts the remaining ones into another linklist
        /// </summary>
        /// <param name="routes">Linklist of routes</param>
        /// <param name="newList">Linklist of popular routes without transit buses</param>
        public void RemoveTransitBuses(RouteLinkList routes, PopularRouteLinkList newList)
        {
            for (PopularRouteNode d = head; d != null; d = d.Link)
            {
                if (d.Data.DepartureCity == routes.CurrentCity)
                {
                    newList.InsertData(d.Data);
                }
            }
        }
    }
}