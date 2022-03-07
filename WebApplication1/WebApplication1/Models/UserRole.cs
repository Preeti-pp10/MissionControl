using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class UserRole
    {
        public int No { get; set; }
        public int? Id { get; set; }
        public int? RoleId { get; set; }
        public bool? IsRole { get; set; }
        public bool? IsAllowRole { get; set; }
    }
}
