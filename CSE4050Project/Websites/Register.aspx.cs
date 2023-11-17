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
        //Change to whatever you named in your SQL
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Register button Click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkEmailID())
            {
                Response.Write("<script>alert('Email already in use.');<script>");
            }
            else
            {
                NewRegister();
                Response.Redirect("Main_Page.aspx"); //Needs testing
            }

        }

        bool checkEmailID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from EXAMPLE where EMAIL = '" + TextBox1.Text.Trim() +"';"
                    , con); //CHANGE TO TABLE NAME AND NAMES

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1) //if 1 that means Email already exists in the database
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');<script>");
                //Catches errors in a display box instead of crashing
                return false;
            }


            
        }

        void NewRegister()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO EXAMPLE(FULL_NAME,EMAIL,PASSWORD), " +
                    "values(@FULL_NAME,@EMAIL,@PASSWORD)", con); //CHANGE TO TABLE NAME AND NAMES

                cmd.Parameters.AddWithValue("@FULL_NAME", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@EMAIL",TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@PASSWORD", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');<script>"); 
                //Catches errors in a display box instead of crashing
            }
        }
    }
}