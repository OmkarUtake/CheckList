using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2Crud.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category required")]
        public string Icategory { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Item { get; set; }

        [Required(ErrorMessage = "Reuiured")]
        public string Description { get; set; }

       
        public int UserId { get; set; }

   
    }
}