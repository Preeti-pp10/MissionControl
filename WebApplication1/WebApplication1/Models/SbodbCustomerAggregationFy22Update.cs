using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SbodbCustomerAggregationFy22Update
    {
        public string Customer { get; set; } = null!;
        public string? AggregatedCustomer { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? FiscalYear { get; set; }
    }
}
