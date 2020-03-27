using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   
  
    public class Person
    {
        [Key]
        public int Person_Id { get; set; }
        [Display(Name = "Reference")]
        public string Ref { get; set; }
        [Display(Name = "Prénom")]
        [Required]
        public string First_Name { get; set; }
        [Display(Name = "Nom")]
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Display(Name = "Date Inscription")]
        [Required]
        public DateTime DateInscri { get; set; }

        public override string ToString()
        {
            return Last_Name+" "+First_Name;
        }

    }
}
