using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApps.Models
{
    public class RegisterViewModel
    {
            [Required]
          [Display(Name = "Nom d'utilisateur")] 
         public string UserName { get; set; }
            [Required]
            [EmailAddress]
            [Remote(action: "IsEmailInUse", controller: "Account")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
            [Display(Name = "Confirmez le mot de passe")]
            [Compare("Password",
                ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
            public string ConfirmPassword { get; set; }
     
        
    }
    
}
