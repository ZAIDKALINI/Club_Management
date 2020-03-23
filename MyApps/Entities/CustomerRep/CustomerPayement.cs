using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class CustomerPayement:Payement
    {
        public int Person_Id { get; set; }
        public virtual Customer customer{ get; set; }
        public int duration { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsEnd { get; set; }
    }
}
