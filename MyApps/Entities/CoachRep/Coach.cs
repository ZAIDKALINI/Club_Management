using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Coach:Person
    {
        public DateTime DateInscri { get; set; } = DateTime.Now;
        
    }
}
