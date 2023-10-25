using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Food_Fate_BLL
{
    public class hashpassword
    {
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(16);
        }

        //used during registration to create the initial hashed password and it's salt as strings
        //stored in the DB as strings but will then need to be converted back to byte arrays
        public string[] CreateHash(string password)
        {
            var salt = CreateSalt();
            var saltstring = Encoding.Unicode.GetString(salt);

            var hash = HashPassword(password, salt);
            var hashstring = Encoding.Unicode.GetString(hash);

            string[] authentication = {hashstring, saltstring };
            return authentication;
        }

        //used during login to verify password 
        //password and salt saved as strings so when retrieved from DB run a Encoding.Unicode.GetBytes(string) to be able to input them into the VerifyHash function
        public bool VerifyHash(string password, byte[] hash, byte[] salt)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

    }
}
