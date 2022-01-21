using Dapper;
using DomainLayer;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Queries
{
    public class GetRoles : IRequest<IList<RolesModel>>
    {
        public class GetRolesHandle : IRequestHandler<GetRoles, IList<RolesModel>>
        {
            private readonly IConfiguration _configuration;
            public GetRolesHandle(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<RolesModel>> Handle(GetRoles query, CancellationToken cancellationToken)
            {
                var sql = "select RoleName from V5_MC_App_Admin_Roles where RoleName ='MC Admin' ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<RolesModel>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
