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
    public class GetRoleById :IRequest<IList<RolesModel>>
    {
        [Required]
        public int Id { get; set; }
        public class GetRoleByIdHandler : IRequestHandler<GetRoleById, IList<RolesModel>>
        {
            private readonly IConfiguration _configuration;
            public GetRoleByIdHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<RolesModel>> Handle(GetRoleById query, CancellationToken cancellationToken)
            {
                var sql = "select r.RoleName, o.Id From V5_MC_App_Admin_Roles r Inner Join User_Role o on r.Id = o.RoleId where o.Id = @Id";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<RolesModel>(sql, new { Id = query.Id });
                    return result.ToList();
                }
            }
        }

    }
}
