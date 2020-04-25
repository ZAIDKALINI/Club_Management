using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Expenses
{
   public class Expense:EntityBase
    {
        [Key]
        public Guid Id_Expense { get; set; }
        public string Description { get; set; }
    
        public double Price { get; set; }
        public DateTime ExpenseDate { get; set; }
        [ForeignKey("category")]
        public Guid Id_Category { get; set; }
        [ForeignKey("Id_Category")]
        public virtual Category_expense category { get; set; }
    }
}
