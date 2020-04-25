using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class CustomerService: PersonService<Customer>
    {
    
        public CustomerService(IUnitOfWork<Customer> _UOW):base(_UOW)
        {
           
        }
       

    }
}
