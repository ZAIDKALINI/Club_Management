using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Payement
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public Decimal Price { get; set; }
        public DateTime Payement_date { get; set; }
      
    }
}
