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
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //Change Con to whatever your SQL user is
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
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from EXAMPLE where EMAIL='" + TextBox1.Text.Trim() + "' AND PASSWORD='" + TextBox2.Text.Trim() + "';"
                    , con);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows) //Checks if one or both are wrong (true and false statement)
                {
                    while (reader.Read())
                    {
                        Response.Write("<script> alert ('Login Successful'); <script>");
                        Session["username"] = reader.GetValue(0).ToString(); //person's username
                        Session["password"] = reader.GetValue(0).ToString(); // ??? not sure yet
                        Session["role"] = "user"; //for master page

                        //Change 0 to the valid row. CHECKING FOR EMAIL ID
                    }
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