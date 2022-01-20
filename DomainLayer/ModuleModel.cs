using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ModuleModel
    {
        public int RoleId { get; set; }
        public string ModuleName { get; set; }
        public bool IsModule { get; set; }
        public bool IsCreate { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsRead { get; set; }
    }
}
