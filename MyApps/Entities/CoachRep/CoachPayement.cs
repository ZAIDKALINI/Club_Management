using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class CoachPayement:Payement
    {
        public int Person_Id { get; set; }
        public virtual Coach Coach { get; set; }
    }
}
