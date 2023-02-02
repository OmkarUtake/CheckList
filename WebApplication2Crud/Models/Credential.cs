using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2Crud.Models
{
    public class Credential

    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Email Id Required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Username Requied")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }


        public string UserRole { get; set; } = "customer";


    }
}