using BusinessLogicLayer;
using DataAccessLayer.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implimentation
{
    public class PayementRepository : GenericBase<CustomerPayement>, IPayementRepository
    {
        public PayementRepository(App_Context db) : base(db)
        {

        }

        public IEnumerable<CustomerPayement> GetWithItems(Func<CustomerPayement, bool> expression)
        {
            return context.CustomerPayements.Include(e => e.customer)
                .Where(expression);
        }

        public CustomerPayement GetByIdWithItems(int id)
        {
            return context.CustomerPayements.Include(e => e.customer).FirstOrDefault(e => e.Id == 1);
        }
    }
}
