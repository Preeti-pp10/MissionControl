using DomainLayer;
using Microsoft.Extensions.Configuration;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ApplicationLayer.Queries
{
    public class GetAllOrdersQuery : IRequest<IList<OrderModel>>
    {
        public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrdersQuery, IList<OrderModel>>
        {
            private readonly IConfiguration _configuration;
            public GetAllOrderQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<OrderModel>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
            {
                var sql = "Select Id,ORDER_NUMBER,PO_NUMBER,TRANS_DATE_YEAR_QUARTER,TRANS_DATE_PERIOD_NAME,REGION,SUB_REGION,DISTRICT from Orders";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<OrderModel>(sql);
                    return result.ToList();
                }
            }



        }
    }
}
