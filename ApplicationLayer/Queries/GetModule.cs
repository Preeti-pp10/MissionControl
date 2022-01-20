using Dapper;
using DomainLayer;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Queries
{
    public class GetModule : IRequest<IList<ModuleModel>>
    {
        [Required]
        public int RoleId { get; set; }

        public class GetModuleHandler : IRequestHandler<GetModule, IList<ModuleModel>>
        {
            private readonly IConfiguration _configuration;
            public GetModuleHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<ModuleModel>> Handle(GetModule query, CancellationToken cancellationToken)
            {
                var sql = "select m.ModuleName,u.IsModule,u.IsCreate,u.IsUpdate,u.IsDelete,u.IsRead , u.RoleId from V5_MC_App_Admin_Module m Inner Join V5_MC_App_Admin_Module_Role_Access_Mapping u on m.Id = u.ModuleId where u.RoleId = @RoleId";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<ModuleModel>(sql, new { RoleId = query.RoleId });
                    return result.ToList();
                }
            }
        }
    }
}
