using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{


    public class Person:EntityBase
    {
        [Key]
        public Guid Person_Id { get; set; }
       
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string Phone { get; set; }
   
        public DateTime DateInscri { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adresse { get; set; }
        public string image { get; set; }
        public Genre genre { get; set; }
      
        public override string ToString()
        {
            return Last_Name+" "+First_Name;
            
        }

    }
   
}
