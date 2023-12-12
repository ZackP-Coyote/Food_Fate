﻿using Food_Fate_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE4050Project.Websites
{
    public partial class User_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = (int)Session["userID"];
            dbBLL dbRef = new dbBLL();
            List<string> favoriteRests = dbRef.getFavorite(userID);
            List<string[]> allRestaraunts = new List<string[]>(); 
            for (int i = 0; i < favoriteRests.Count; i++)
            {
                LookUp LU = new LookUp();
                string[] restinfo = LU.BL(favoriteRests[i]).Result;
                string[] neededInfo = { restinfo[1], restinfo[2], restinfo[3]/*, restinfo[4]*/ };
                allRestaraunts.Add(neededInfo);
            }
            try
            {
                //List<BOService> service = dALService.Service.ToList();
                if (allRestaraunts.Count > 0 && allRestaraunts != null)
                {
                    GridView1.DataSource = allRestaraunts;
                    GridView1.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
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
                /*currently having issues with this since it seems the old password textbox is not coded correctly. 
                 also maybe have a check in the html or maybe even here to make sure both textbox2 and textbox4 are filled*/
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
    }
}