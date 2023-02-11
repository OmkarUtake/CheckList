using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2Crud.BuisnessLayer.User.Interfaces;
using WebApplication2Crud.CommonFactors;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.User.Classes
{
    public class RegisterUser : IRegisterUser
    {
        CategoryDbContext database = new CategoryDbContext();

        public bool IsExist(Credential cd)
        {
            bool userIsUniqe = database.Credentials.Any(x => x.UserName == cd.UserName);
            bool emailIsUnique = database.Credentials.Any(x => x.EmailId == cd.EmailId);

            if (userIsUniqe == false && emailIsUnique == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RegisterUserDetails(Credential cd)
        {
            cd.Password = PasswordEncoder.Encode(cd.Password);
            cd.UserRole = "customer";
            database.Credentials.Add(cd);
            database.SaveChanges();
        }
    }
}