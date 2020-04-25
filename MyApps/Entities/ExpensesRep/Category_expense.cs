using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Expenses
{
    public class Category_expense:EntityBase
    {
        [Key]
        public Guid Id_Category { get; set; }
        public string Name_Category { get; set; }
    }
}
