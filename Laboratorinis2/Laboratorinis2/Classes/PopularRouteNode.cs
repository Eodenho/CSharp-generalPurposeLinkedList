using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Popular routes node class
    /// </summary>
    public sealed class PopularRouteNode
    {
        public PopularRoute Data { get; set; }
        public PopularRouteNode Link { get; set; }
        public PopularRouteNode() { }
        public PopularRouteNode(PopularRoute data, PopularRouteNode address)
        {
            this.Data = data;
            this.Link = address;
        }
    }
}