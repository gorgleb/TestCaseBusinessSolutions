using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseBusinessSolutions.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }

        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        [ValidateNever]
        public Provider Provider { get; set; }

    }
}
