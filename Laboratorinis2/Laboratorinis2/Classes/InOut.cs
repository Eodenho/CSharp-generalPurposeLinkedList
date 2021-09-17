using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Laboratorinis2.Classes
{
    /// <summary>
    /// Class for reading and printing
    /// </summary>
    public static class InOut
    {
        /// <summary>
        /// Reads routes from a file
        /// </summary>
        /// <param name="fileName">File with routes</param>
        /// <returns>Linklist of route</returns>
        public static RouteLinkList ReadRoutes(string fileName)
        {
            RouteLinkList routes = new RouteLinkList();
            using (var reader = new StreamReader(fileName))
            {
                string line;
                routes.CurrentCity = line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string departureCity = values[0];
                    TimeSpan departureTime = TimeSpan.Parse(values[1]);
                    string arrivalCity = values[2];
                    TimeSpan arrivalTime = TimeSpan.Parse(values[3]);
                    int day = int.Parse(values[4]);
                    Route newRoute = new Route(departureCity, departureTime, arrivalCity, arrivalTime, day);
                    routes.InsertData(newRoute);
                }
            }
            return routes;
        }
        /// <summary>
        /// Reads file with route prices
        /// </summary>
        /// <param name="fileName">Route prices</param>
        /// <returns>Route prices</returns>
        public static RoutePriceLinkList ReadRoutesPrices(string fileName)
        {
            RoutePriceLinkList routesPrices = new RoutePriceLinkList();
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string arrivalcity = values[0];
                    double price = double.Parse(values[1]);
                    RoutePrice newPrice = new RoutePrice(arrivalcity, price);
                    routesPrices.InsertData(newPrice);
                }
            }
            return routesPrices;
        }
        /// <summary>
        /// Prints routes to txt file
        /// </summary>
        /// <param name="fileName">File thats being printed to</param>
        /// <param name="routes">Linklist of routes</param>
        /// <param name="header">Header</param>
        public static void PrintRoutesToTxt(string fileName, RouteLinkList routes, string header)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(new string('-', 95));
                writer.WriteLine(String.Format("| {0,-91} |", header));
                writer.WriteLine(new string('-', 95));
                writer.WriteLine(String.Format("| {0,-18} | {1,-16} | {2,-18} | {3,-17} | {4,-10} |", "Isvykimo miestas", "Isvykimo laikas", "Atvykimo miestas", "Atvykimo laikas", "Diena"));
                writer.WriteLine(new string('-', 95));
                for (routes.Head(); routes.Exists(); routes.Link())
                {
                    writer.WriteLine(routes.Get().ToString());
                }
                writer.WriteLine(new string('-', 95));
            }
        }
        public static void PrintStartingInfoToTXT(string fileName, RouteLinkList routes, string header,RoutePriceLinkList prices)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(new string('-', 95));
                writer.WriteLine(String.Format("| {0,-91} |", header));
                writer.WriteLine(new string('-', 95));
                writer.WriteLine(String.Format("| {0,-18} | {1,-16} | {2,-18} | {3,-17} | {4,-10} |", "Isvykimo miestas", "Isvykimo laikas", "Atvykimo miestas", "Atvykimo laikas", "Diena"));
                writer.WriteLine(new string('-', 95));
                for (routes.Head(); routes.Exists(); routes.Link())
                {
                    writer.WriteLine(routes.Get().ToString());
                }
                writer.WriteLine(new string('-', 95));
                writer.WriteLine("");
                writer.WriteLine(new string('-', 30));
                writer.WriteLine(String.Format("| {0,-26} |", header));
                writer.WriteLine(new string('-', 30));
                writer.WriteLine(String.Format("| {0,-16} | {1,-7} |", "Atvykimo miestas", "Kaina"));
                writer.WriteLine(new string('-', 30));
                for (prices.Head(); prices.Exists(); prices.Link())
                {
                    writer.WriteLine(prices.Get().ToString());
                }
                writer.WriteLine(new string('-', 30));
            }
        }
        /// <summary>
        /// Prints routes to txt with price
        /// </summary>
        /// <param name="fileName">File that is being printed to</param>
        /// <param name="routes">Linklist of routes</param>
        /// <param name="header">Header</param>
        /// <param name="price">Prices of routes</param>
        public static void PrintCheapestRoutesToTxt(string fileName, RouteLinkList routes, string header, RoutePriceLinkList price)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(new string('-', 108));
                writer.WriteLine(String.Format("| {0,-104} |", header));
                writer.WriteLine(new string('-', 108));
                writer.WriteLine(String.Format("| {0,-18} | {1,-16} | {2,-18} | {3,-17} | {4,-10} | {5,-10} |", "Isvykimo miestas", "Isvykimo laikas", "Atvykimo miestas", "Atvykimo laikas", "Diena", "Kaina"));
                writer.WriteLine(new string('-', 108));
                for (routes.Head(); routes.Exists(); routes.Link())
                {
                    writer.WriteLine(String.Format("| {0,-18} | {1,-16} | {2,-18} | {3,-17} | {4,-10} | {5,-10:f2} |", routes.Get().DepartureCity, routes.Get().DepartureTime, routes.Get().ArrivalCity, routes.Get().ArrivalTime, routes.Get().Day, routes.CheapestRoutesPrice(routes, price)));
                }
                writer.WriteLine(new string('-', 108));
            }
        }
        /// <summary>
        /// Prints popular routes to txt
        /// </summary>
        /// <param name="fileName">File that is being printed to</param>
        /// <param name="routes">Popular route linklist</param>
        /// <param name="header">Header</param>
        public static void PrintPopularRoutesToTxt(string fileName, PopularRouteLinkList routes, string header)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(new string('-', 74));
                writer.WriteLine(String.Format("| {0,-70} |", header));
                writer.WriteLine(new string('-', 74));
                writer.WriteLine(String.Format("| {0,-18} | {1,-16} | {2,-17} | {3,-10} |", "Isvykimo miestas", "Isvykimo laikas", "Atvykimo laikas", "Diena"));
                writer.WriteLine(new string('-', 74));
                for (routes.Head(); routes.Exists(); routes.Link())
                {
                    writer.WriteLine(routes.Get().ToString());
                }
                writer.WriteLine(new string('-', 74));
            }
        }
        /// <summary>
        /// Prints route prices to txt
        /// </summary>
        /// <param name="fileName">File that is being printed to</param>
        /// <param name="prices">Prices of routes</param>
        /// <param name="header">Header</param>
        public static void PrintPricesToTxt(string fileName, RoutePriceLinkList prices, string header)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(new string('-', 48));
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 48));
                writer.WriteLine(String.Format("| {0,-18} | {1,-7} |", "Atvykimo miestas", "Kaina"));
                writer.WriteLine(new string('-', 48));
                for (prices.Head(); prices.Exists(); prices.Link())
                {
                    writer.WriteLine(prices.Get().ToString());
                }
                writer.WriteLine(new string('-', 48));
            }
        }
        /// <summary>
        /// Prints routes to web
        /// </summary>
        /// <param name="list">Linklist of routes</param>
        /// <param name="table">Empty table</param>
        /// <param name="label">Empty label</param>
        /// <param name="header">Header</param>
        public static void PrintRoutesToWeb(RouteLinkList list,Table table, Label label , string header)
        {
            label.Text = header;
            TableRow topRow = new TableRow();
            TableCell departureCity = new TableCell();
            departureCity.Text = "Išvykimo miestas";
            topRow.Cells.Add(departureCity);
            TableCell departureTime = new TableCell();
            departureTime.Text = "Išvykimo laikas";
            topRow.Cells.Add(departureTime);
            TableCell arrivalCity = new TableCell();
            arrivalCity.Text = "Atvykimo miestas";
            topRow.Cells.Add(arrivalCity);
            TableCell arrivalTime = new TableCell();
            arrivalTime.Text = "Atvykimo laikas";
            topRow.Cells.Add(arrivalTime);
            TableCell day = new TableCell();
            day.Text = "Diena";
            topRow.Cells.Add(day);
            table.Rows.Add(topRow);
            for (list.Head(); list.Exists(); list.Link())
            {
                Route route = list.Get();
                TableRow row = new TableRow();
                TableCell routeDepartureCity = new TableCell();
                routeDepartureCity.Text = route.DepartureCity;
                row.Cells.Add(routeDepartureCity);
                TableCell routeDepartureTime = new TableCell();
                routeDepartureTime.Text = Convert.ToString(route.DepartureTime);
                row.Cells.Add(routeDepartureTime);
                TableCell routeArrivalCity = new TableCell();
                routeArrivalCity.Text = route.ArrivalCity;
                row.Cells.Add(routeArrivalCity);
                TableCell routeArrivalTime = new TableCell();
                routeArrivalTime.Text = Convert.ToString(route.ArrivalTime);
                row.Cells.Add(routeArrivalTime);
                TableCell routeDay = new TableCell();
                routeDay.Text = Convert.ToString(route.Day);
                row.Cells.Add(routeDay);
                table.Rows.Add(row);
            }
        }
        /// <summary>
        /// Prints route prices to web
        /// </summary>
        /// <param name="prices">Linklist of prices</param>
        /// <param name="table">Empty table</param>
        /// <param name="label">Empty label</param>
        public static void PrintPricesToWeb(RoutePriceLinkList prices, Table table, Label label)
        {
            label.Text = "Maršrutų kainos:";
            TableRow topRow = new TableRow();
            TableCell topPrice = new TableCell();
            topPrice.Text = "Kaina";
            topRow.Cells.Add(topPrice);
            TableCell topCity = new TableCell();
            topCity.Text = "Atvykimo miestas";
            topRow.Cells.Add(topCity);
            table.Rows.Add(topRow);
            for (prices.Head(); prices.Exists(); prices.Link())
            {
                RoutePrice routePrice = prices.Get();
                TableRow row = new TableRow();
                TableCell price = new TableCell();
                price.Text = String.Format("{0:f2} eur", routePrice.Price);
                row.Cells.Add(price);
                TableCell city = new TableCell();
                city.Text = routePrice.ArrivalCity;
                row.Cells.Add(city);
                table.Rows.Add(row);
            }
        }
        /// <summary>
        /// Prints popular routes to web
        /// </summary>
        /// <param name="list">Popular route linklist</param>
        /// <param name="table">Empty table</param>
        /// <param name="label">Empty label</param>
        /// <param name="header">Header</param>
        public static void PrintPopularRoutesToWeb(PopularRouteLinkList list, Table table, Label label, string header)
        {
            label.Text = header;
            TableRow topRow = new TableRow();
            TableCell departureCity = new TableCell();
            departureCity.Text = "Išvykimo miestas";
            topRow.Cells.Add(departureCity);
            TableCell departureTime = new TableCell();
            departureTime.Text = "Išvykimo laikas";
            topRow.Cells.Add(departureTime);
            TableCell arrivalTime = new TableCell();
            arrivalTime.Text = "Atvykimo laikas";
            topRow.Cells.Add(arrivalTime);
            TableCell day = new TableCell();
            day.Text = "Diena";
            topRow.Cells.Add(day);
            list.Head();
            if (list.Exists())
            {
                table.Rows.Add(topRow);
            } 
            else
            {
                TableRow infoRow = new TableRow();
                TableCell tableInfo = new TableCell();
                tableInfo.Text = "Netranzitinių maršrutų nėra.";
                infoRow.Cells.Add(tableInfo);
                table.Rows.Add(infoRow);
            }
            for (list.Head(); list.Exists(); list.Link())
            {
                PopularRoute route = list.Get();
                TableRow row = new TableRow();
                TableCell routeDepartureCity = new TableCell();
                routeDepartureCity.Text = route.DepartureCity;
                row.Cells.Add(routeDepartureCity);
                TableCell routeDepartureTime = new TableCell();
                routeDepartureTime.Text = Convert.ToString(route.DepartureTime);
                row.Cells.Add(routeDepartureTime);
                TableCell routeArrivalTime = new TableCell();
                routeArrivalTime.Text = Convert.ToString(route.ArrivalTime);
                row.Cells.Add(routeArrivalTime);
                TableCell routeDay = new TableCell();
                routeDay.Text = Convert.ToString(route.Day);
                row.Cells.Add(routeDay);
                table.Rows.Add(row);
            }
        }
        /// <summary>
        /// Prints routes with prices to a web
        /// </summary>
        /// <param name="list">Linklist of routes</param>
        /// <param name="table">Empty table</param>
        /// <param name="label">Empty label</param>
        /// <param name="header">Header</param>
        /// <param name="prices">Linklist of prices</param>
        public static void PrintRoutesWithPricesToWeb(RouteLinkList list, Table table, Label label, string header, RoutePriceLinkList prices)
        {
            label.Visible = true;
            label.Text = header;
            TableRow topRow = new TableRow();
            TableCell departureCity = new TableCell();
            departureCity.Text = "Išvykimo miestas";
            topRow.Cells.Add(departureCity);
            TableCell departureTime = new TableCell();
            departureTime.Text = "Išvykimo laikas";
            topRow.Cells.Add(departureTime);
            TableCell arrivalCity = new TableCell();
            arrivalCity.Text = "Atvykimo miestas";
            topRow.Cells.Add(arrivalCity);
            TableCell arrivalTime = new TableCell();
            arrivalTime.Text = "Atvykimo laikas";
            topRow.Cells.Add(arrivalTime);
            TableCell day = new TableCell();
            day.Text = "Diena";
            topRow.Cells.Add(day);
            TableCell price = new TableCell();
            price.Text = "Kaina";
            topRow.Cells.Add(price);
            table.Rows.Add(topRow);
            for (list.Head(); list.Exists(); list.Link())
            {
                Route route = list.Get();
                TableRow row = new TableRow();
                TableCell routeDepartureCity = new TableCell();
                routeDepartureCity.Text = route.DepartureCity;
                row.Cells.Add(routeDepartureCity);
                TableCell routeDepartureTime = new TableCell();
                routeDepartureTime.Text = Convert.ToString(route.DepartureTime);
                row.Cells.Add(routeDepartureTime);
                TableCell routeArrivalCity = new TableCell();
                routeArrivalCity.Text = route.ArrivalCity;
                row.Cells.Add(routeArrivalCity);
                TableCell routeArrivalTime = new TableCell();
                routeArrivalTime.Text = Convert.ToString(route.ArrivalTime);
                row.Cells.Add(routeArrivalTime);
                TableCell routeDay = new TableCell();
                routeDay.Text = Convert.ToString(route.Day);
                row.Cells.Add(routeDay);
                TableCell routePrice = new TableCell();
                routePrice.Text = String.Format("{0:f2} eur",list.CheapestRoutesPrice(list,prices));
                row.Cells.Add(routePrice);
                table.Rows.Add(row);
            }
        }
    }
}