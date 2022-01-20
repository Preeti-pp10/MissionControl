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
    public class GetUsersById : IRequest<IList<UserModel>>
    {
        [Required]
        public string UserName { get; set; }
        public class GetUsersByIdHandler : IRequestHandler<GetUsersById, IList<UserModel>>
        {
            private readonly IConfiguration _configuration;
            public GetUsersByIdHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<UserModel>> Handle(GetUsersById query, CancellationToken cancellationToken)
            {
                var sql = "Select * from V5_MC_App_Admin_Users Where UserName =@UserName";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<UserModel>(sql, new { UserName = query.UserName });
                    return result.ToList();
                }
            }
        }
    }
}
