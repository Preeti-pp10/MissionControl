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
    public class GetCustomersById : IRequest<IList<MCCustomerModel>>
    {
        [Required]
        public int Id { get; set; }
        public class GetCustomersByIdHandler : IRequestHandler<GetCustomersById, IList<MCCustomerModel>>
        {
            private readonly IConfiguration _configuration;
            public GetCustomersByIdHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<MCCustomerModel>> Handle(GetCustomersById query, CancellationToken cancellationToken)
            {
                var sql = "Select * from MC_App_Customer_Aggregation where Id=@Id";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<MCCustomerModel>(sql, new { Id = query.Id });
                    return result.ToList();
                }
            }
        }
    }
}
