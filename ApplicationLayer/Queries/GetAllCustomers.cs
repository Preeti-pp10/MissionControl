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
    public class GetAllCustomers : IRequest<IList<MCCustomerModel>>
    {
    
        public string customer { get; set; }
       
      

        public class GetAllCustomersHandler : IRequestHandler<GetAllCustomers, IList<MCCustomerModel>>
        {
            private readonly IConfiguration _configuration;
            public GetAllCustomersHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<MCCustomerModel>> Handle(GetAllCustomers query, CancellationToken cancellationToken)
            {

                var sql = "SELECT nv.Id,nv.customer,nv.aggregated_customer,nv.entry_date,nv.fiscal_year FROM MC_App_Customer_Aggregation nv WHERE nv.customer LIKE '%' + @customer + '%'";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<MCCustomerModel>(sql, new { customer = query.customer});
                    return result.ToList();
                }
            }
        }
    }
}
