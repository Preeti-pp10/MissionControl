using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppAdminSystemUserRole
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public bool? IsRole { get; set; }
        public bool? IsAllowRole { get; set; }
    }
}
