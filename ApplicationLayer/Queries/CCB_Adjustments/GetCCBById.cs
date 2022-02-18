using Dapper;
using DomainLayer.CCB;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Queries.CCB_Adjustments
{
    public class GetCCBById : IRequest<IList<oracle_n_vias>>
    {
        public string ORDER_NUMBER { get; set; }
        public class GetCCBByIdHandler : IRequestHandler<GetCCBById, IList<oracle_n_vias>>
        {
            private readonly IConfiguration _configuration;

            public GetCCBByIdHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<oracle_n_vias>> Handle(GetCCBById query, CancellationToken cancellationToken)
            {
                var sql = "Select REGION,SUB_REGION,ORDER_NUMBER,PO_NUMBER,DISTRICT,L3_BUSINESS_GROUP,L4_BUSINESS_UNIT,L5_PRODUCT_LINE,TRANS_DATE_PERIOD_NAME,CC_AMT_GROSS_BOOKINGS,TRANS_DATE from V6_dwh_bookings_oracle_n_vias Where ORDER_NUMBER =@ORDER_NUMBER";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<oracle_n_vias>(sql, new { ORDER_NUMBER  = query.ORDER_NUMBER });
                    return result.ToList();
                }
            }
        }
    }
}
