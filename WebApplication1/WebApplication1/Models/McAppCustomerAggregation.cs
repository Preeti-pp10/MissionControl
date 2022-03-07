using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class McAppCustomerAggregation
    {
        public int Id { get; set; }
        public string Customer { get; set; } = null!;
        public string? AggregatedCustomer { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? FiscalYear { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
    }
}
