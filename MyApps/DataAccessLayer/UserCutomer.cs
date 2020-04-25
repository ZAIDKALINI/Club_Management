using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class UserCutomer
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public string IdUSer { get; set; }
        [ForeignKey("IdUSer")]
        public ApplicationUser User { get; set; }
        [ForeignKey("customer")]
        public Guid IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public Customer customer { get; set; }
    }
}
