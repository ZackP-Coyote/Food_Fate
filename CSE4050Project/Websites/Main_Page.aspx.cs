using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE4050Project
{
    public partial class Main_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Redirect_Click(object sender, EventArgs e)
        {
            //YelpApi yelpApi = new YelpApi();
            //string[] searcharr = { TextBox1.Text.Trim(), TextBox2.Text.Trim(), DropDownList1.SelectedValue.Trim() };
            //yelpApi.Main(searcharr);
            //Response.Redirect("Search_Results.aspx");

            Response.Redirect("Search_Results.aspx?city=" + ZipCity.Text.Trim() + "&radius=" + Radius.Text.Trim() + "&value=" + Filters.SelectedValue.Trim());

        }
    }
}