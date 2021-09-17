using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Class for route price node
    /// </summary>
    public sealed class RoutePriceNode
    {
        public RoutePrice Data { get; set; }
        public RoutePriceNode Link { get; set; }
        public RoutePriceNode() { }
        public RoutePriceNode(RoutePrice data, RoutePriceNode address)
        {
            this.Data = data;
            this.Link = address;
        }
    }
}