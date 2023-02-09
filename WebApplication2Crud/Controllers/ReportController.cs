using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using WebApplication2Crud.Models;
using WebApplication2Crud.ViewModel;

namespace WebApplication2Crud.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        public ReportController()
        {

        }
        CategoryDbContext Db = new CategoryDbContext();

        [Authorize(Roles = "admin")]
        public ActionResult ReportByUser()
        {


            // readonly string Cs = ConfigurationManager.ConnectionStrings["CategoryDbContext"].ConnectionString;
            // SqlConnection con = new SqlConnection(Cs);
            //SqlCommand cmd = new SqlCommand("PassworDecoder", con)
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

            List<Report> reportList = new List<Report>();
            var data = Db.Database.SqlQuery<Report>("sp_generateReport");
            foreach (var report in data)
            {
                Report obj = new Report
                {
                    Icategory = report.Icategory,
                    item = report.item,
                    UserName = report.UserName,
                    Date = report.Date
                };
                reportList.Add(obj);
            }

            return View(reportList);
        }
    }
}