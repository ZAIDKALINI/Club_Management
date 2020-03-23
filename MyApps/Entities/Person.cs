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
        public string Ref { get; set; }
       
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string Telephone { get; set; }

        public override string ToString()
        {
            return Last_Name+" "+First_Name;
        }

    }
}
