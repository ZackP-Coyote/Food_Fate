using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Food_Fate_BLL;
using static System.Net.WebRequestMethods;

namespace CSE4050Project.Websites
{
    public partial class Search_Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ZipCity = Request.QueryString["city"];
            string Radius = Request.QueryString["radius"];
            string Filters = Request.QueryString["value"];
            YelpApi yelpApi= new YelpApi();
            string[] searcharr = { ZipCity, Radius, Filters} ;
            yelpApi.Main(searcharr);

            //string ZC = Request.QueryString["ZipCity"];
            string R = Request.QueryString["Radius"];

            string imageurl1 = "https://i.natgeofe.com/n/4cebbf38-5df4-4ed0-864a-4ebeb64d33a4/NationalGeographic_1468962_3x2.jpg?w=1638&h=1092";
            
            Restaurant_Image_1.Controls.Add(new Literal() { Text = "<div> <img width=300px src=" + imageurl1 + "alt=Resturant 1 Image></div>" });



            string nameurl = "https://www.w3schools.com/html/html_images.asp";
            string resname = "W3Schools";
            Restaurant_Name_1.Controls.Add(new Literal() { Text = "<div> <a href=" + nameurl + ">" + resname + "</a></div>" });

            string Place = "Place";
            Restaurant_Description_1.Controls.Add(new Literal() { Text = "<div>" + Place + "</div>" });

            
        }

        protected void SearchAgainButton(object sender, EventArgs e)
        {
            //YelpApi yelpApi= new YelpApi();
            //string[] searcharr = { TextBox1.Text.Trim(), TextBox2.Text.Trim(), DropDownList1.SelectedValue.Trim() } ;
            // yelpApi.Main(searcharr);
            Response.Redirect("Search_Results.aspx?city=" + ZipCity.Text.Trim() + " & radius= " + Radius.Text.Trim() + " & value=" + Filters.SelectedValue.Trim());

        }

       
    }
}