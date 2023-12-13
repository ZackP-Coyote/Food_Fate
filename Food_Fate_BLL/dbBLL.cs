using Food_Fate_DAL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Food_Fate_BLL
{
    public class dbBLL
    {
        //returns 1 when able to add user. returns 0 if not able to. returns -2 if email already in DB
        public int SignUp(string userEmail, string userName, string Password)
        {
            hashpassword hp = new hashpassword();
            string[] auth = hp.CreateHash(Password);
            dbfunctions df = new dbfunctions();
            var status = df.DBSignUp(userEmail, userName, auth[0], auth[1]);
            return status;
        }

        //returns the users ID which so it can be made into a session variable
        //returns -1 if user doesn't exist or failed to login
        public int LogIn(string userEmail, string password)
        {
            dbfunctions df = new dbfunctions();
            string[] verify = df.RetrieveHashSalt(userEmail);

            if (verify[0] == null)
            {
                return -1;
            }

            byte[] pass = System.Convert.FromBase64String(verify[0]);
            byte[] salt = System.Convert.FromBase64String(verify[1]);

            hashpassword hp = new hashpassword();

            bool authorized = hp.VerifyHash(password, pass, salt);
            if (authorized == true)
            {
                var id = df.GetUserID(userEmail);
                return id;
            }
            return -1;
        }

        public int setFavorite(int userID, string restID)
        {
            dbfunctions df = new dbfunctions();
            var r = df.DBFavorite(userID, restID);
            return r;
        }

        //array where userEmail is at index 0, userName at 1, userImage at 2
        public string[] GetUserInfo(int userID)
        {
            dbfunctions df = new dbfunctions();
            var mydr = df.DBGetUserInfo(userID);
            return mydr;
        }

        //returns a list of strings which are the IDs for the restaurants favorited by the user
        public List<string> getFavorite(int userID)
        {
            dbfunctions df = new dbfunctions();
            var r = df.DBGetFavorites(userID);
            return r;
        }

        //UpdatesUserInfo with new values. if email is updated to an email in use returns -2
        //returns 0 if unable to update, 1 if able to
        public int UpdateUserInfo(int userID, string userEmail, string userName, string userImage)
        {
            dbfunctions df = new dbfunctions();
            var r = df.DBUpdateUserInfo(userID, userEmail, userName, userImage);
            return r;
        }

        //updates Password returns 1 if able to 0 if not
        public int UpdatePassword(int userID, string oldpassword, string newpassword)
        {
            dbfunctions df = new dbfunctions();
            string[] verify = df.RetrieveHashSalt2(userID);

            byte[] pass = System.Convert.FromBase64String(verify[0]);
            byte[] salt = System.Convert.FromBase64String(verify[1]);

            hashpassword hp = new hashpassword();

            bool authorized = hp.VerifyHash(oldpassword, pass, salt);
            if (authorized == true)
            {
                string[] auth = hp.CreateHash(newpassword);
                var r = df.DBUpdatePassword(userID, auth[0], auth[1]);
                return r;
            }
            return 0;
        }

        //returns 1 if able to. returns 0 if userID doesn't exist
        public int DeleteUser(int userID) 
        {
            dbfunctions df = new dbfunctions();
            var r = df.DBDeleteUser(userID);
            return r;
        }

        //returns 1 if restaurant already favorited. 0 if not
        public int CheckFavorite(int userID, string favID)
        {
            dbfunctions df = new dbfunctions();
            var r = df.DBCheckFavorite(userID, favID);
            return r;
        }

        //returns 1 if able to. returns 0 if not
        public int RemoveFavorite(int userID, string favID)
        {
            dbfunctions df = new dbfunctions();
            var r = df.DBRemoveFavorite(userID, favID);
            return r;
        }
    }
}
