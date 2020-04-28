using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApps.Models
{
    public class UserCustomerViewModel
    {
      
        public string userName { get; set; }

        public Guid Person_Id { get; set; }
   
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string Telephone { get; set; }
        public string image { get; set; }



    }
   


}
