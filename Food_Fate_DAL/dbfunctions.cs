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
        //returns 1 when able to add user. returns 0 if not able to. returns -2 if email already in DB
        public int DBSignUp(string userEmail, string userName, string hashedPassword, string hashSalt)
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

                //password and salt saved as strings so when retrieved run a Encoding.Unicode.GetBytes(string) for VerifyHash function
                using (var cmd = new SqlCommand("insert into AuthTable values ("+userID+", '"+hashedPassword+"', '"+hashSalt+",)", conn))
                {
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                    return response;
                }    
            }
        }

        //Adds a userID, restID pairing to the database and returns 1 if it works, 0 if it doesn't
        public int DBFavorite(int userID, string restID/*, string restName, string restDescription, string restImage*/)
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

        //returns the userID as an int
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

        //returns a SqlDataReader variable with userEmail at index 0, userName at 1, and userImage at 2
        //if needed I can change it so it can return a string[] with the values at the same index
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
        
        //returns a SqlDataReader of x favorites starting at an index of 0
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

        //function to retrieve the hashed password and salt which will then be made into byte[] for VerifyHash function
        public string[] RetrieveHashSalt(string userEmail)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                int userID = GetUserID(userEmail);
                using (var cmd = new SqlCommand("select userPassword, userSalt from AuthTable where userID='" + userID + "'", conn))
                {
                    string hash;
                    string salt;
                    string[] strings = new string[2];

                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        hash = dr.GetString(0);
                        salt = dr.GetString(1);
                    }
                    else
                    {
                        return strings;
                    }
                    strings[0] = hash;
                    strings[1] = salt;
                    return strings;
                }
            }
        }
    }
}
