using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2Crud.ViewModel
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string Icategory { get; set; }
        public string item { get; set; }
        public string UserName { get; set; }

        public DateTime Date { get; set; }
    }
}