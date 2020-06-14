﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Paginate
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public List<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
            
            
        }
    }
}
