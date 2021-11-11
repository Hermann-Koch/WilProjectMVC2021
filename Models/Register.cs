using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WilProjectMVC2021.Models
{
    public class Register
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string idUser { get; set; }

        [Required(ErrorMessage = "Please enter a valid email for your account.")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter a valid email for your account.")]
        [DisplayName("Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid cellphone number.")]
        [DisplayName("Cellphone")]
        [DataType(DataType.PhoneNumber)]
        public string Cellphone { get; set; }

        [Required(ErrorMessage = "Please enter a valid password for your account.")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}