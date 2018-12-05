using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EAI.Template.API.Model
{
   public class LoginModel
    {
        [Required(ErrorMessage ="{0} is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
    }
}
