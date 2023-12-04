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

        }

        protected void SearchAgainButton(object sender, EventArgs e)
        {
            XXX.Text = "Search Results";
            YelpApi yelpApi= new YelpApi();
            string[] searcharr = { TextBox1.Text.Trim(), TextBox2.Text.Trim(), DropDownList1.SelectedValue.Trim() } ;
            yelpApi.Main(searcharr);
            Response.Redirect("Search_Results.aspx");
            
        }
    }
}