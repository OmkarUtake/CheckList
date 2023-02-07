using System.ComponentModel.DataAnnotations;

namespace WebApplication2Crud.Models
{
    public class Credential
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Email Id Required")]
        [EmailAddress(ErrorMessage = "ENter valid mail id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Username Requied")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }


        public string UserRole { get; set; }


    }
}