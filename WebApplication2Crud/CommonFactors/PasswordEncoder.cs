using System;
using System.Text;

namespace WebApplication2Crud.CommonFactors
{
    public class PasswordEncoder
    {
        public static string Encode(string password)
        {
            byte[] EncData = ASCIIEncoding.ASCII.GetBytes(password);
            string encryptedpass = Convert.ToBase64String(EncData);
            return encryptedpass;
        }
    }
}