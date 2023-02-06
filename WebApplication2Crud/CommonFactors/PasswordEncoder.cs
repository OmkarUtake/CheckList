using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

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