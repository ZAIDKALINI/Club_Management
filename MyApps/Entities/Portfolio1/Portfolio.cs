using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Portfolio
{
    public class Portfolio : EntityBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
