using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DTOs
{
    public class PaymentDTO
    {
        public int StudentId { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
