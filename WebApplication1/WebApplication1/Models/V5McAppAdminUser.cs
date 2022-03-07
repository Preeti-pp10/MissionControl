using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppAdminUser
    {
        public int Id { get; set; }
        public string? EmpId { get; set; }
        public string? EmailId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public bool? IsGlobalAdmin { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
    }
}
