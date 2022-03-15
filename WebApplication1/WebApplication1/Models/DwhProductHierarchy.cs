using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class DwhProductHierarchy
    {
        public string ProdLineKey { get; set; } = null!;
        public string? ProdLineDesc { get; set; }
        public string? Level9Desc { get; set; }
        public string? Level9 { get; set; }
        public string? Level8Desc { get; set; }
        public string? Level8 { get; set; }
        public string? Level7Desc { get; set; }
        public string? Level7 { get; set; }
        public string? Level6Desc { get; set; }
        public string? Level6 { get; set; }
        public string? Level5Desc { get; set; }
        public string? Level5 { get; set; }
        public string? Level4Desc { get; set; }
        public string? Level4 { get; set; }
        public string? Level3Desc { get; set; }
        public string? Level3 { get; set; }
        public string? Level2Desc { get; set; }
        public string? Level2 { get; set; }
        public string? Level10Desc { get; set; }
        public string? Level10 { get; set; }
        public string? Level1Desc { get; set; }
        public string? Level1 { get; set; }
        public string? ProdLineCode { get; set; }
        public string? ParentFlag { get; set; }
        public string? PlmName { get; set; }
        public string? PlmSupervisorName { get; set; }
        public string? SalesLevel3 { get; set; }
        public string? SalesLevel3Desc { get; set; }
        public double? CommtestIntercoUpliftFactor { get; set; }
    }
}
