using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.User.Interfaces
{
    public interface IRegisterUser
    {
        bool IsExist(Credential cd);
        void RegisterUserDetails(Credential cd);
    }
}
