using Food_Fate_BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE4050Project.Websites
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Register button Click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            dbBLL dbRef = new dbBLL();
            int res = dbRef.SignUp(TextBox1.Text.Trim(), TextBox3.Text.Trim(), TextBox2.Text.Trim());
            if (res == -2)
            {
                Response.Write("<script>alert('Email already in use.');<script>");
            }
            else
            {
                Response.Redirect("Main_Page.aspx"); //Needs testing
            }

        }
    }
}