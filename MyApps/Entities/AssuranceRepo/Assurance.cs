using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Assurance
    {
        [Key]
        public int Id { get; set; }
        public string Descreption { get; set; }
        public virtual Customer customer { get; set; }
        public double  Prix { get; set; }
        public virtual TypeAssurance Type { get; set; }
    }
}
