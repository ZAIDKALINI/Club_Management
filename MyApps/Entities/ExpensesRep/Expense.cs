using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Expenses
{
   public class Expense
    {
        private ILazyLoader _lazyLoder;
        private Category_expense _category;
        public Expense()
        {

        }
        public Expense(ILazyLoader lazyLoder)
        {
            _lazyLoder = lazyLoder;
        }
        [Key]
        public int Id_Expense { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpenseDate { get; set; }
        [ForeignKey("category")]
        public int Id_Category { get; set; }
        [ForeignKey("Id_Category")]
        public virtual Category_expense category { get=>_lazyLoder.Load(this, ref _category); set=>_category=value; }
    }
}
