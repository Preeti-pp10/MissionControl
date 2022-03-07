using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppAdminRole
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public string? RoleCode { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
