using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.Interfaces
{
    public interface IDetails
    {
          Task<Category> ProductDetail(int id);
    }
}
