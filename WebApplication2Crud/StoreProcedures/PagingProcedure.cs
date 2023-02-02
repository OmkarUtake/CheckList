using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.StoreProcedures
{

    public class PagingProcedure
    {
        CategoryDbContext db = new CategoryDbContext();


        public List<Category> IndexPagePaging(double b, int a, out int dataCount)
        {
            dataCount = db.Categories.Count();

            SqlParameter[] valu = new SqlParameter[]
            {
                new SqlParameter("@Pagesize",b),
                new SqlParameter("@Pageinde",a)

             };
            var data = db.Categories.SqlQuery("sp_Paging @Pageinde,@Pagesize", valu).ToList();

            return data;


        }





    }
}