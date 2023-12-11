﻿using System;
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
        private string id1;
        private string id2;
        private string id3;
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
            id1 = businessInfo[0][0];
            string name1 = businessInfo[0][1];
            string imageurl1 = businessInfo[0][4];
            string rating1 = businessInfo[0][3];
            string url1 = businessInfo[0][5];

            id2 = businessInfo[1][0];
            string name2 = businessInfo[1][1];
            string imageurl2 = businessInfo[1][4];
            string rating2 = businessInfo[1][3];
            string url2 = businessInfo[1][5];

            id3 = businessInfo[2][0];
            string name3 = businessInfo[2][1];
            string imageurl3 = businessInfo[2][4];
            string rating3 = businessInfo[2][3];
            string url3 = businessInfo[2][5];


            //Restaurant Results
            Restaurant_Image_1.Controls.Add(new Literal() { Text = "<div> <img width=300px src=" + imageurl1 + " alt=Resturant 1 Image></div>" });
            Restaurant_Name_1.Controls.Add(new Literal() { Text = "<div> <a href=" + url1 + ">" + name1 + "</a></div>" });
            Restaurant_Description_1.Controls.Add(new Literal() { Text = "<div> Rating:" + rating1 + "</div>" });

            Restaurant_Image_2.Controls.Add(new Literal() { Text = "<div> <img width=300px src=" + imageurl2 + " alt=Resturant 2 Image></div>" });
            Restaurant_Name_2.Controls.Add(new Literal() { Text = "<div> <a href=" + url2 + ">" + name2 + "</a></div>" });
            Restaurant_Description_2.Controls.Add(new Literal() { Text = "<div> Rating:" + rating2 + "</div>" });

            Restaurant_Image_3.Controls.Add(new Literal() { Text = "<div> <img width=300px src=" + imageurl3 + " alt=Resturant 3 Image></div>" });
            Restaurant_Name_3.Controls.Add(new Literal() { Text = "<div> <a href=" + url3 + ">" + name3 + "</a></div>" });
            Restaurant_Description_3.Controls.Add(new Literal() { Text = "<div> Rating:" + rating3 + "</div>" });


            
        }

        protected void SearchAgainButton(object sender, EventArgs e)
        {
            //YelpApi yelpApi= new YelpApi();
            //string[] searcharr = { TextBox1.Text.Trim(), TextBox2.Text.Trim(), DropDownList1.SelectedValue.Trim() } ;
            // yelpApi.Main(searcharr);
            Response.Redirect("Search_Results.aspx?city=" + ZipCity.Text.Trim() + "&radius=" + Radius.Text.Trim() + "&value=" + Filters.SelectedValue.Trim());

        }

        protected void FavoriteButton1_Click(object sender, EventArgs e)
        {
            int userID = (int)Session["userID"];
            dbBLL dbRef = new dbBLL();
            int res = dbRef.setFavorite(userID, id1);
        }

        protected void FavoriteButton2_Click(object sender, EventArgs e)
        {
            int userID = (int)Session["userID"];
            dbBLL dbRef = new dbBLL();
            int res = dbRef.setFavorite(userID, id2);
        }

        protected void FavoriteButton3_Click(object sender, EventArgs e)
        {
            int userID = (int)Session["userID"];
            dbBLL dbRef = new dbBLL();
            int res = dbRef.setFavorite(userID, id3);
        }
    }
}