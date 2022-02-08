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
    public class GetOrderRemapQuery : IRequest<IList<OrderRemap>>
    {
        public class GetOrderRemapQueryHandler : IRequestHandler<GetOrderRemapQuery, IList<OrderRemap>>
        {
            private readonly IConfiguration _configuration;
            public GetOrderRemapQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<OrderRemap>> Handle(GetOrderRemapQuery request, CancellationToken cancellationToken)
            {
                var sql = "Select  ID,Order_Number,PO_Number,REGION,SUB_REGION,DISTRICT,New_Region,New_Subregion,New_District,Period,Start_Quarter,Method,Standard_Reason,Comments,Is_Anaplan_TQM,Is_Approved_Move_To_New_Region from Order_Remap";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<OrderRemap>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
