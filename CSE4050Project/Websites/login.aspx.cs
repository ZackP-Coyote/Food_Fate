using Food_Fate_BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE4050Project
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //idk why this is here, can be removed
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbBLL dbRef = new dbBLL();
                int res = dbRef.LogIn(TextBox1.Text.Trim(), TextBox2.Text.Trim());

                if (res > -1) //Checks if one or both are wrong (true and false statement)
                {
                    string[] info = dbRef.GetUserInfo(res);

                    Response.Write("<script> alert ('Login Successful'); <script>");
                    Session["userID"] = res; //sets userID as session variable for usage in other db functions
                    Session["username"] = info[1]; //person's username
                    Session["role"] = "user"; //for master page

                    Response.Redirect("Main_Page.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Email or Password');<script>");
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');<script>");
                //Catches errors in a display box instead of crashing
            }
        }

        //custom defined functions



    }
}