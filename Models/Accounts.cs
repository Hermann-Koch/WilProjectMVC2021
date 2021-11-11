using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WilProjectMVC2021.Models
{
    public class Accounts
    {
        [Required(ErrorMessage = "Please enter your Email")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}