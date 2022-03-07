using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class OrderAudit
    {
        public int Id { get; set; }
        public string? OrderNumber { get; set; }
        public string? PoNumber { get; set; }
        public string? SalesRepNumber { get; set; }
        public string? Region { get; set; }
        public string? NewRegion { get; set; }
        public string? SubRegion { get; set; }
        public string? NewSubregion { get; set; }
        public string? District { get; set; }
        public string? NewDistrict { get; set; }
        public string? Period { get; set; }
        public string? StartQuarter { get; set; }
        public string? EndQuarter { get; set; }
        public string? Method { get; set; }
        public string? Comments { get; set; }
        public string? StandardReason { get; set; }
        public string? RemapPerson { get; set; }
        public string? RemapType { get; set; }
        public DateTime? RemapDate { get; set; }
        public bool? IsAnaplanTqm { get; set; }
        public bool? IsApprovedMoveToNewRegion { get; set; }
        public bool? IsActive { get; set; }
    }
}
