using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public string RegisterUserDetails(Credential cd)
        {
            bool userIsUniqe = database.Credentials.Any(x => x.UserName == cd.UserName);
            bool emailIsUnique = database.Credentials.Any(x => x.EmailId == cd.EmailId);

            if (userIsUniqe == false && emailIsUnique == false)
            {
                cd.Password = PasswordEncoder.Encode(cd.Password);
                database.Credentials.Add(cd);
                database.SaveChanges();
                return "Registered Successfully";
            }
            else
            {
                return "User Already Exist";
            }
        }
    }
}