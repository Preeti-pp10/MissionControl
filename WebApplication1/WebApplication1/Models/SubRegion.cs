using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SubRegion
    {
        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string? SubRegion1 { get; set; }
    }
}
