using System.Linq;
using WebApplication2Crud.BuisnessLayer.User.Interfaces;
using WebApplication2Crud.CommonFactors;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.User.Classes
{
    public class Authentication : IAuthentication
    {
        CategoryDbContext Database = new CategoryDbContext();

        public bool IsValidUser(Credential cd, out string userToken)
        {
            if (cd.UserName != null && cd.Password != null)
            {
                cd.Password = PasswordEncoder.Encode(cd.Password);
                var user = Database.Credentials.SingleOrDefault(x => x.UserName == cd.UserName && x.Password == cd.Password);
                if (user != null)
                {
                    cd.UserRole = user.UserRole;
                    var token = JWTHelper.CreateJWTToken(cd);
                    userToken = token;
                    //FormsAuthentication.SetAuthCookie(cd.UserName, false);
                    return true;
                }

                userToken = null;
                return false;
            }
            else
            {
                userToken = null;
                return false;
            }
        }
    }
}
