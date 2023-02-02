using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2Crud.ViewModel
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string Icategory { get; set; }
        public string item { get; set; }
        public string UserName { get; set; }
    }
}