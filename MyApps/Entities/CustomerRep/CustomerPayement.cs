using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class CustomerPayement:Payement
    {
        private ILazyLoader _lazyLoader;
        public CustomerPayement()
        {

        }
        public CustomerPayement(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        private Customer _customer;
        [ForeignKey("customer")]
        public int Person_Id { get; set; }
        [ForeignKey("Person_Id")]
        public Customer customer
        {
            get => _lazyLoader.Load(this, ref _customer);
            set => _customer = value;
        }
        public int duration { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsEnd { get; set; }
    }
}
