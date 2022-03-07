using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppCustomerAggregationAudit
    {
        public int Id { get; set; }
        public string Customer { get; set; } = null!;
        public string? AggregatedCustomer { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? FiscalYear { get; set; }
        public string? Type { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
