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
    public class GetRole : IRequest<IList<RolesModel>>
    {
       
        public class GetRoleHandle : IRequestHandler<GetRole, IList<RolesModel>>
        {
            private readonly IConfiguration _configuration;
            public GetRoleHandle(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<RolesModel>> Handle(GetRole query, CancellationToken cancellationToken)
            {
                var sql = "select RoleName from V5_MC_App_Admin_Roles  ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<RolesModel>(sql );
                    return result.ToList();
                }
            }
        }
    }
}
