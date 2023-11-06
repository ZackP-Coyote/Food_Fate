using Food_Fate_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int status = df.DBSignUp(userEmail, userName, auth[0], auth[1]);
            return status;
        }

        public bool LogIn(string userEmail, string password)
        {
            dbfunctions df = new dbfunctions();
            string[] verify = df.RetrieveHashSalt(userEmail);

            byte[] pass = System.Convert.FromBase64String(verify[0]);
            byte[] salt = System.Convert.FromBase64String(verify[1]);

            hashpassword hp = new hashpassword();

            bool authorized = hp.VerifyHash(password, pass, salt);
            return authorized;
        }
    }
}
