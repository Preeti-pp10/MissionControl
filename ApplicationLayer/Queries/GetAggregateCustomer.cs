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
    public class GetAggregateCustomer :IRequest<IList<MCCustomerModel>>
    {
        public string aggregated_customer { get; set; }
        public class GetAggregateCustomerHandler : IRequestHandler<GetAggregateCustomer, IList<MCCustomerModel>>
        {
            private readonly IConfiguration _configuration;
            public GetAggregateCustomerHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<MCCustomerModel>> Handle(GetAggregateCustomer query, CancellationToken cancellationToken)
            {

                var sql = "SELECT nv.aggregated_customer FROM MC_App_Customer_Aggregation nv WHERE nv.aggregated_customer LIKE '%' + @aggregated_customer + '%' ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<MCCustomerModel>(sql, new { aggregated_customer = query.aggregated_customer });
                    return result.ToList();
                }
            }
        }
    }
}
