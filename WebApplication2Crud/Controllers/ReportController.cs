using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using WebApplication2Crud.Models;
using WebApplication2Crud.ViewModel;

namespace WebApplication2Crud.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        CategoryDbContext Db = new CategoryDbContext();
        readonly string Cs = ConfigurationManager.ConnectionStrings["CategoryDbContext"].ConnectionString;

        public ActionResult ReportByUser()
        {
            List<Report> reportList = new List<Report>();
            SqlConnection con = new SqlConnection(Cs);
            SqlCommand cmd = new SqlCommand("sp_generateReport", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Report report = new Report
                {
                    UserName = reader.GetValue(0).ToString(),
                    item = reader.GetValue(1).ToString(),
                    Icategory = reader.GetValue(2).ToString()
                };
                reportList.Add(report);
            }


            return View(reportList);
        }
    }
}