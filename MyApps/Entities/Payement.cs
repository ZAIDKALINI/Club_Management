﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Payement:EntityBase
    {
        public Guid Id { get; set; }
        public string Ref { get; set; }
        public double Price { get; set; }
        public DateTime Payement_date { get; set; }
      
    }
}
