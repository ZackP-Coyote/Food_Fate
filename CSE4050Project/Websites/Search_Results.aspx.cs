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
            List<string[]> businessInfo = yelpApi.BSAsync(searcharr).Result;

            //string ZC = Request.QueryString["ZipCity"];
            //string R = Request.QueryString["Radius"];

            
        

            //fetch id, name , image, and url from businessInfo
            string id1 = businessInfo[0][0];
            string name1 = businessInfo[0][1];
            string imageurl1 = businessInfo[0][5];
            string rating1 = businessInfo[0][3];
            string url1 = businessInfo[0][6];

            string id2 = businessInfo[1][0];
            string name2 = businessInfo[1][1];
            string imageurl2 = businessInfo[1][5];
            string url2 = businessInfo[1][6];

            string id3 = businessInfo[2][0];
            string name3 = businessInfo[2][1];
            string imageurl3 = businessInfo[2][5];
            string url3 = businessInfo[2][6];



            //string imageurl1 = "https://i.natgeofe.com/n/4cebbf38-5df4-4ed0-864a-4ebeb64d33a4/NationalGeographic_1468962_3x2.jpg?w=1638&h=1092";

            Restaurant_Image_1.Controls.Add(new Literal() { Text = "<div> <img width=300px src=" + imageurl1 + "alt=Resturant 1 Image></div>" });
           // string nameurl = "https://www.w3schools.com/html/html_images.asp";
           // string resname = "W3Schools";
            Restaurant_Name_1.Controls.Add(new Literal() { Text = "<div> <a href=" + url1 + ">" + name1 + "</a></div>" });

            //string Place = "Place";
            Restaurant_Description_1.Controls.Add(new Literal() { Text = "<div>" + rating1 + "</div>" });

            
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