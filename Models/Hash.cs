using System;
using System.Security.Cryptography;
using System.Text;
namespace Final3312
{
    public class Hash
    {
        public static string hash256(string text,string salt)
        {
            SHA256 hashstring = SHA256.Create();
            byte[] hash = hashstring.ComputeHash(Encoding.UTF8.GetBytes(text+salt));
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}