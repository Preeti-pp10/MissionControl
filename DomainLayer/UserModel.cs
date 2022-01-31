using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class UserModel
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
        
    }
}
