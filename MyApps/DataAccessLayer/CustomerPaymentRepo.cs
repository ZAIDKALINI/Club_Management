using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    class CustomerPaymentRepo
    {

        App_Context db;
      
        public CustomerPaymentRepo(App_Context db)
        {
            this.db = db;
           
        }
    }
}
