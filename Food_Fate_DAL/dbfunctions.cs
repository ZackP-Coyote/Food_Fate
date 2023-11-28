using MySqlConnector;
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
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("select * from UserInfo where userEmail='" + userEmail + "'", conn))
                {
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return -2;
                    }
                }
            }
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("insert into UserInfo values (0, '" + userEmail + "', '" + userName + "', 'https://d1csarkz8obe9u.cloudfront.net/posterpreviews/profile-design-template-4c23db68ba79c4186fbd258aa06f48b3_screen.jpg?ts=1581063859')", conn))
                {
                    int response = cmd.ExecuteNonQuery();
                    if (response == 0)
                    {
                        return response;
                    }
                }
            }
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                conn.Open();
                int userID = GetUserID(userEmail);

                //password and salt saved as strings so when retrieved run a System.Convert.FromBase64String for VerifyHash function
                using (var cmd = new MySqlCommand("insert into AuthTable values (" + userID + ", '" + hashedPassword + "', '" + hashSalt + "')", conn))
                {
                    int response = cmd.ExecuteNonQuery();
                    return response;
                }
            }
        }

        //Adds a userID, restID pairing to the database and returns 1 if it works, 0 if it doesn't
        public int DBFavorite(int userID, string restID/*, string restName, string restDescription, string restImage*/)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("insert into FavRest values (" + userID + ", '" + restID + "')"/*, '"+restName+"', '"+restDescription+ "', '"+restImage+"')"*/, conn))
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
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("select userID from UserInfo where userEmail='" + userEmail + "'", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    var dr = cmd.ExecuteReader();
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
        public string[] DBGetUserInfo(int userID)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("select userEmail, userName, userImage from UserInfo where userID=" + userID + "", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    var dr = cmd.ExecuteReader();

                    string[] strings = new string[3];
                    if (dr.Read())
                    {
                        strings[0] = dr.GetString(0);
                        strings[1] = dr.GetString(1);
                        strings[2] = dr.GetString(2);
                    }
                    return strings;
                }
            }
        }

        //returns a SqlDataReader of x favorites starting at an index of 0
        public List<string> DBGetFavorites(int userID)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("select restID from FavRest where userID='" + userID + "'", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    var dr = cmd.ExecuteReader();

                    List<string> favorites = new List<string>();
                    while (dr.Read())
                    {
                        favorites.Add(dr.GetString(0));
                    }

                    return favorites;
                }
            }
        }

        //function to retrieve the hashed password and salt which will then be made into byte[] for VerifyHash function
        public string[] RetrieveHashSalt(string userEmail)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                int userID = GetUserID(userEmail);
                using (var cmd = new MySqlCommand("select userPassword, userSalt from AuthTable where userID='" + userID + "'", conn))
                {
                    string hash;
                    string salt;

                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        hash = dr.GetString(0);
                        salt = dr.GetString(1);
                    }
                    else
                    {
                        string[] empty = new string[2];
                        return empty;
                    }
                    string[] bytes = { hash, salt };
                    return bytes;
                }
            }
        }

        //same as above but for updatepassword functionality.
        public string[] RetrieveHashSalt2(int userID)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("select userPassword, userSalt from AuthTable where userID='" + userID + "'", conn))
                {
                    string hash;
                    string salt;

                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        hash = dr.GetString(0);
                        salt = dr.GetString(1);
                    }
                    else
                    {
                        string[] empty = new string[2];
                        return empty;
                    }
                    string[] bytes = { hash, salt };
                    return bytes;
                }
            }
        }

        //UpdatesUserInfo with new values. if email is updated to an email in use returns -2
        //returns 0 if unable to update, 1 if able to
        public int DBUpdateUserInfo(int userID, string userEmail, string userName, string userImage)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("select * from UserInfo where userEmail='" + userEmail + "' and userID !=" + userID + "", conn))
                {
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return -2;
                    }
                }
            }
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("update UserInfo set userEmail='" + userEmail + "', userName='" + userName + "', userImage='" + userImage + "' where userID=" + userID + "", conn))
                {
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                    return response;
                }
            }
        }

        //updates Password returns 1 if able to 0 if not
        public int DBUpdatePassword(int userID, string hashedPassword, string hashSalt)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("update AuthTable set userPassword='" + hashedPassword + "', userSalt='" + hashSalt + "' where userID=" + userID + "", conn))
                {
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                    return response;
                }
            }
        }

        //returns 1 if able to. returns 0 if userID doesn't exist
        public int DBDeleteUser(int userID)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("delete from AuthTable where userID=" + userID + "", conn))
                {
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                }
            }
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("delete from FavRest where userID=" + userID + "", conn))
                {
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                }
            }
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("delete from UserInfo where userID="+userID+"", conn))
                {
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                    return response;
                }
            }
        }

        //returns 1 if able to. returns 0 if not
        public int DBRemoveFavorite(int userID, string favID)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DataCon"].ToString()))
            {
                using (var cmd = new MySqlCommand("delete from FavRest where userID=" + userID + " and restID='"+favID+"'", conn))
                {
                    conn.Open();
                    int response = cmd.ExecuteNonQuery();
                    return response;
                }
            }
        }
    }
}
