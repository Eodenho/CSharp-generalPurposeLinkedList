using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboratorinis2.Classes;

namespace Laboratorinis2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly string df1 = HttpContext.Current.Server.MapPath("App_Data/U2a.txt");
        private readonly string df2 = HttpContext.Current.Server.MapPath("App_Data/U2b.txt");
        protected void Page_Load(object sender, EventArgs e)
        {
            RouteLinkList allRoutes = InOut.ReadRoutes(df1);
            RoutePriceLinkList allRoutesPrices = InOut.ReadRoutesPrices(df2);
            InOut.PrintRoutesToWeb(allRoutes, Table1, Label1, String.Format("{0} autobusų stotis", allRoutes.CurrentCity));
            InOut.PrintPricesToWeb(allRoutesPrices, Table2, Label2);
            if (DropDownList1.Items.Count == 0)
            {
                for (int i = 1; i <= 7; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                }
            }
            Label4.Visible = false;
            InOut.PrintStartingInfoToTXT(HttpContext.Current.Server.MapPath("App_Data/PradiniaiDuomenys.txt"), allRoutes, "Pradiniai duomenys",allRoutesPrices);
            PopularRouteLinkList popularRoutes = allRoutes.PopularRoutes();
            popularRoutes.Sort();
            PopularRouteLinkList newPopularList = new PopularRouteLinkList();
            popularRoutes.RemoveTransitBuses(allRoutes, newPopularList);
            InOut.PrintPopularRoutesToTxt(HttpContext.Current.Server.MapPath("App_Data/Populiariausi.txt"), newPopularList, "Populiariausias miestas:  " + allRoutes.FindMostPopularRoute());
            InOut.PrintPopularRoutesToWeb(newPopularList, Table3, Label3, "Populiariausias miestas: " + allRoutes.FindMostPopularRoute());
        }
        static bool Validation(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RouteLinkList allRoutes = InOut.ReadRoutes(df1);
            RoutePriceLinkList allRoutesPrices = InOut.ReadRoutesPrices(df2);
            if (Validation(start.ToString()) && Validation(finish.ToString()) && Validation(DropDownList1.Text))
            {
                TimeSpan startTime = TimeSpan.Parse(start.Value);
                TimeSpan finishTime = TimeSpan.Parse(finish.Value);
                RouteLinkList possibleTravels = allRoutes.CanTravel(int.Parse(DropDownList1.Text), TextBox1.Text, startTime, finishTime);
                RouteLinkList cheapestRoutes = possibleTravels.CheapestRoutes(possibleTravels);
                if (cheapestRoutes.Exists())
                {
                    InOut.PrintRoutesWithPricesToWeb(cheapestRoutes, Table4, Label4, "Pigiausios įmanomos kelionės",allRoutesPrices);
                    InOut.PrintCheapestRoutesToTxt(HttpContext.Current.Server.MapPath("App_Data/Pigiausi.txt"), cheapestRoutes, "Pigiausi marsrutai", allRoutesPrices);
                }
                else
                {
                    Label4.Visible = true;
                    Label4.Text = "Įmanomų kelionių nėra";
                }
            } 
        }
    }
}