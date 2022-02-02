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
    public class GetCustomers : IRequest<IList<CustomerModel>>
    {
        
        public string CUSTOMER_NAME { get; set; }
        public class GetCustomersHandler : IRequestHandler<GetCustomers, IList<CustomerModel>>
        {
            private readonly IConfiguration _configuration;
            public GetCustomersHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<CustomerModel>> Handle(GetCustomers query, CancellationToken cancellationToken)
            {
               
                var sql = "SELECT nv.CUSTOMER_NAME FROM V6_dwh_bookings_oracle_n_vias nv WHERE nv.CUSTOMER_NAME LIKE '%' + @CUSTOMER_NAME + '%' and nv.CUSTOMER_NAME NOT IN (SELECT customer FROM MC_App_Customer_Aggregation)";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<CustomerModel>(sql, new { CUSTOMER_NAME = query.CUSTOMER_NAME });
                    return result.ToList();
                }
            }
        }
    }
}
