using Entities;
using Entities.Expenses;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interface
{
    interface IPayementRepository
    {
        CustomerPayement GetByIdWithItems(int id);
        IEnumerable<CustomerPayement> GetWithItems(Func<CustomerPayement, bool> expression);
    }
}
