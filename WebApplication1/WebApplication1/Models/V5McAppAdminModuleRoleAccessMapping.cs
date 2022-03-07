using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppAdminModuleRoleAccessMapping
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? ModuleId { get; set; }
        public bool? IsModule { get; set; }
        public bool? IsCreate { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsRead { get; set; }
    }
}
