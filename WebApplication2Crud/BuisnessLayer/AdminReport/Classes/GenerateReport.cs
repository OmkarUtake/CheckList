using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2Crud.BuisnessLayer.AdminReport.Interfaces;
using WebApplication2Crud.Models;
using WebApplication2Crud.ViewModel;

namespace WebApplication2Crud.BuisnessLayer.AdminReport.Classes
{
    public class GenerateReport : IReport
    {
        CategoryDbContext db = new CategoryDbContext();
        public List<Report> Report()
        {
            List<Report> reportList = new List<Report>();
            var data = db.Database.SqlQuery<Report>("sp_generateReport");
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
            return reportList;
        }
    }
}