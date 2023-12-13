using Food_Fate_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE4050Project.Websites
{
    public partial class User_Profile : System.Web.UI.Page
    {
        List<string> restUrls = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = (int)Session["userID"];
                BindData(userID);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dbBLL bLL = new dbBLL();
            int uID = (int)Session["userID"];
            int res = bLL.UpdateUserInfo(uID, TextBox1.Text.Trim(), TextBox3.Text.Trim(), "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/profile-design-template-4c23db68ba79c4186fbd258aa06f48b3_screen.jpg?ts=1581063859");
            if (res == -2)
            {
                Response.Write("Email already in use.");
            }
            else if (res == 1)
            {
                /*currently having issues with this since it seems the old password textbox is not coded correctly.*/
                int res2 = bLL.UpdatePassword(uID, TextBox2.Text.Trim(), TextBox4.Text.Trim());
                if (res2 == 1)
                {
                    Response.Write("Successfully updated user information.");
                }
                else
                {
                    Response.Write("Unable to update user password.");
                }
            }
            else
            {
                Response.Write("Unable to update user information.");
            }
        }

        protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            int userID = (int)Session["userID"];

            dbBLL dbRef = new dbBLL();
            int res = dbRef.RemoveFavorite(userID, id);


            BindData(userID);
        }

        private void BindData(int userID)
        {
            dbBLL dbRef = new dbBLL();
            List<string> favoriteRests = dbRef.getFavorite(userID);

            List<string[]> allRestaraunts = new List<string[]>();

            for (int i = 0; i < favoriteRests.Count; i++)
            {
                LookUp LU = new LookUp();
                string[] restinfo = LU.BL(favoriteRests[i]).Result;
                string[] neededInfo = { favoriteRests[i], restinfo[1], restinfo[2], restinfo[3], restinfo[4] };
                allRestaraunts.Add(neededInfo);
            }

            var dt = new DataTable();
            var reID = dt.Columns.Add("rest_id", Type.GetType("System.String"));
            var reName = dt.Columns.Add("rest_name", Type.GetType("System.String"));
            var reLocation = dt.Columns.Add("rest_location", Type.GetType("System.String"));
            var reRating = dt.Columns.Add("rest_rating", Type.GetType("System.String"));

            for (int i = 0; i < favoriteRests.Count; i++)
            {
                var dr = dt.NewRow();
                dr["rest_id"] = allRestaraunts[i][0];
                dr["rest_name"] = allRestaraunts[i][1];
                dr["rest_location"] = allRestaraunts[i][2];
                dr["rest_rating"] = allRestaraunts[i][3];
                restUrls.Add(allRestaraunts[i][4]);

                dt.Rows.Add(dr);
            }


            try
            {
                if (allRestaraunts.Count > 0 && allRestaraunts != null)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    int index = e.Row.RowIndex;
                    hl.NavigateUrl = restUrls[index];
                }
            }
        }
    }
}