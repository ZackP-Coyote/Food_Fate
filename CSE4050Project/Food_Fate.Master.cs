using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE4050Project
{
    public partial class Food_Fate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; //Login button
                    LinkButton2.Visible = true; //Register button

                    LinkButton3.Visible = false; //logout button
                    LinkButton7.Visible = false; //hello user button

                    LinkButton6.Visible = true; //Admin link button

                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //Login button
                    LinkButton2.Visible = false; //Register button

                    LinkButton3.Visible = true; //logout button
                    LinkButton7.Visible = true; //hello user button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();

                    LinkButton6.Visible = true; //Admin link button
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');<script>");
                //Catches errors in a display box instead of crashing
            }



        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Login.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //Clears everything for the logout button 
            Session["username"] = ""; //person's username
            Session["password"] = ""; // ??? not sure yet
            Session["role"] = ""; //for master page
            LinkButton1.Visible = true; //Login button
            LinkButton2.Visible = true; //Register button

            LinkButton3.Visible = false; //logout button
            LinkButton7.Visible = false; //hello user button

            LinkButton6.Visible = true; //Admin link button
            Response.Redirect("Main_Page.aspx");
        }
    }
}