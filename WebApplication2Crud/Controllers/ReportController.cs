using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebApplication2Crud.BuisnessLayer.AdminReport.Interfaces;
using WebApplication2Crud.Models;
using WebApplication2Crud.ViewModel;

namespace WebApplication2Crud.Controllers
{

    public class ReportController : Controller
    {
        // readonly string Cs = ConfigurationManager.ConnectionStrings["CategoryDbContext"].ConnectionString;


        private readonly IReport _report;
        public ReportController(IReport report)
        {
            _report = report;
        }
        CategoryDbContext Db = new CategoryDbContext();

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult ReportByUser()
        {
            //List<Report> reportList = new List<Report>();

            //SqlConnection con = new SqlConnection(Cs);
            //SqlCommand cmd = new SqlCommand("sp_generateReport", con)
            //{
            //    CommandType = System.Data.CommandType.StoredProcedure
            //};
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    Report report = new Report
            //    {
            //        UserName = reader.GetValue(0).ToString(),
            //        item = reader.GetValue(1).ToString(),
            //        Icategory = reader.GetValue(2).ToString()
            //    };
            //    reportList.Add(report);
            //}


            var reportList = _report.Report();

            return View(reportList);
        }
    }
}