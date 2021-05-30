using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ExpTrack.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [DisplayName("Expense")]
        public string ExpenseName { get; set; }
        [DisplayName("Value")]
        public double ExpenseValue { get; set; }

    }
}
