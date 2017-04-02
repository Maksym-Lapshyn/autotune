using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace autotune.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}