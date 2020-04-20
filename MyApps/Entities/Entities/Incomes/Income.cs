using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Incomes
{
    public class Income
    {
        [Key]
        public int Id_Income { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime IncomeDate { get; set; }
        public int Id_CategoryIncome { get; set; }
        public virtual Category_income category { get; set; }
    }
}
