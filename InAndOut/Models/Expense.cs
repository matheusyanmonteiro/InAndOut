using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense name")]
        [Required]
        public string ExpensesName { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount Must be Greater than 0,01!")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Amount { get; set; }
    }
}
