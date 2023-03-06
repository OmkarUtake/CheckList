using System.Web.Mvc;
using WebApplication2Crud.BuisnessLayer.AdminReport.Interfaces;
using WebApplication2Crud.CommonFactors;

namespace WebApplication2Crud.Controllers
{

    public class ReportController : Controller
    {
        private readonly IReport _report;
        public ReportController(IReport report)
        {
            _report = report;
        }

        [HttpGet]
        [Route("Report")]
        [Authorize(Roles = "admin")]
        [CustFilter]
        public ActionResult ReportByUser()
        {
            var reportList = _report.Report();
            return View(reportList);
        }
    }
}