using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Portfolio
{
    public class Owner : EntityBase
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Profil { get; set; }
        public string Avatar { get; set; }
    }
}
