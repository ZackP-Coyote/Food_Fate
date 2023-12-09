using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Food_Fate_BLL;

namespace CSE4050Project.Websites
{
    public partial class Search_Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            YelpApi yelpApi= new YelpApi();
            string[] searcharr = { ZipCity.Text.Trim(), Radius.Text.Trim(), Filters.SelectedValue.Trim() } ;
            yelpApi.Main(searcharr);

            //string ZC = Request.QueryString["ZipCity"];
            string R = Request.QueryString["Radius"];



            Image Testing = new Image();
            Testing.ImageUrl = "Testing";
            Restaurant_Image_1.Controls.Add(Testing);

            Button Restaurant_Button_1 = new Button();
            Restaurant_Button_1.Text = "testing";
            Restaurant_Name_1.Controls.Add(Restaurant_Button_1);

            Label Restaurant_Desc_1 = new Label();
            Restaurant_Desc_1.Text = "Testing";
            Restaurant_Description_1.Controls.Add(Restaurant_Desc_1);
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