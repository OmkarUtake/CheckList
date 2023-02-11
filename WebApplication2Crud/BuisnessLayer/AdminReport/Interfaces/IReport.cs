using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2Crud.ViewModel;

namespace WebApplication2Crud.BuisnessLayer.AdminReport.Interfaces
{
    public interface IReport
    {
        List<Report> Report();
    }
}
