using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.Interfaces
{
    public interface IEdit
    {
         Task Update(Category data);
    }
}
