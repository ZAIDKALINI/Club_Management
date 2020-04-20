using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   public class TypeAssurance
    {
        [Key]
        public int Id { get; set; }
        public string Name_assurance { get; set; }
    }
}
