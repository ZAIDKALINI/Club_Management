using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Customer:Person
    {
        [Display(Name ="Date Inscription")]
        public DateTime DateInscri { get; set; }
    }
}
