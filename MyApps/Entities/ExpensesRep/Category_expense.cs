﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Expenses
{
    public class Category_expense
    {
        [Key]
        public int Id_Category { get; set; }
        public string Name_Category { get; set; }
    }
}
