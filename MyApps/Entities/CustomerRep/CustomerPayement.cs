using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EntityFrameworkCore.Triggers;
namespace Entities
{
    public class CustomerPayement:Payement
    {
        [ForeignKey("customer")]
        public Guid Person_Id { get; set; }
        [ForeignKey("Person_Id")]
        public virtual Customer customer{ get; set; }
        public int duration { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsEnd { get; set; }
       
    }
}
