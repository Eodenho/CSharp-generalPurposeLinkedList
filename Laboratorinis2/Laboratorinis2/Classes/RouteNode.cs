using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Route node class
    /// </summary>
    public sealed class RouteNode
    {
        public Route Data { get; set; }
        public RouteNode Link { get; set; }
        public RouteNode() { }
        public RouteNode(Route data, RouteNode address)
        {
            this.Data = data;
            this.Link = address;
        }
    }
}