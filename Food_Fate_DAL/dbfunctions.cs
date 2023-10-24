using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Fate_DAL
{
    public class dbfunctions
    {
        public int SignUp(string userEmail, string userName, string hashedPassword)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new SqlCommand("select * from UserInfo where userEmail='"+userEmail+"'"))
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return -2;
                    }
                }
                using (var cmd = new SqlCommand("insert into UserInfo values (0, '"+userEmail+ "', '"+userName+"', 'https://d1csarkz8obe9u.cloudfront.net/posterpreviews/profile-design-template-4c23db68ba79c4186fbd258aa06f48b3_screen.jpg?ts=1581063859')", conn)) 
                { 
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                    if (response == 0)
                    {
                        return response;
                    }
                }

                int userID = GetUserID(userEmail);

                using (var cmd = new SqlCommand("insert into AuthTable values ("+userID+", '"+hashedPassword+"')", conn))
                {
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                    return response;
                }    
            }
        }

        public int Favorite(int userID, string restID/*, string restName, string restDescription, string restImage*/)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new SqlCommand("insert into FavRest values ("+userID+", '"+restID+"')"/*, '"+restName+"', '"+restDescription+ "', '"+restImage+"')"*/, conn))
                {
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                    return response;
                }
            }
        }

        public int GetUserID(string userEmail) 
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new SqlCommand("select userID from UserInfo where userEmail='"+userEmail+"'", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return dr.GetInt32(0);
                    }   
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        public SqlDataReader GetUserInfo(int userID)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new SqlCommand("select userEmail, userName, userImage from UserInfo where userID="+userID+"", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    return dr;
                }
            }
        }

        public SqlDataReader GetFavorites(int userID)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new SqlCommand("select restID from FavRest where userID='"+userID+"'", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    return dr;
                }
            }
        }
    }
}
