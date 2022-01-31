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
    public class Role : IRequest<IList<RolesModel>>
    {
        [Required]
        public int Id { get; set; }
        public class RoleHandle : IRequestHandler<Role, IList<RolesModel>>
        {
            private readonly IConfiguration _configuration;
            public RoleHandle(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<RolesModel>> Handle(Role query, CancellationToken cancellationToken)
            {
                var sql = "select Id,RoleName from V5_MC_App_Admin_Roles Where Id =@Id";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<RolesModel>(sql, new {Id = query.Id});
                    return result.ToList();
                }
            }
        }
    }
}
