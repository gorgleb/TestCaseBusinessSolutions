using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseBusinessSolutions.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        

    }
}
