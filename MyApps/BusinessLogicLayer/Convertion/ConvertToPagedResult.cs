using Entities.Paginate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Convertion
{
    public  class ConvertToPagedResult<T> where T : class
    {
        public static PagedResult<T> PagedResult(List<T> lst)
        {
            PagedResult<T> pagedResult = new PagedResult<T>();
            pagedResult.Results.AddRange(lst);
            return pagedResult ;

        }
    }
}
