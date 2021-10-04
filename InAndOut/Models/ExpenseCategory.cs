using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
