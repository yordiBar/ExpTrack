using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpTrack.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense")]
        [Required]
        public string ExpenseName { get; set; }
        [DisplayName("Value")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="Value Must be greater than 0.01!")]
        public double ExpenseValue { get; set; }

    }
}
