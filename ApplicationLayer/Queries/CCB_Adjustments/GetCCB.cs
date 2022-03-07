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
    public class GetCCB : IRequest<IList<oracle_n_vias>>
    {
        public class GetCCBHandler : IRequestHandler<GetCCB, IList<oracle_n_vias>>
        {
            private readonly IConfiguration _configuration;

            public GetCCBHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<oracle_n_vias>> Handle(GetCCB request, CancellationToken cancellationToken)
            {
                var sql = " Select REGION,SUB_REGION,ORDER_NUMBER,PO_NUMBER,DISTRICT,L3_BUSINESS_GROUP,L4_BUSINESS_UNIT,L5_PRODUCT_LINE,TRANS_DATE_PERIOD_NAME,CC_AMT_GROSS_BOOKINGS,TRANS_DATE from V6_dwh_bookings_oracle_n_vias WHERE ORDER_NUMBER NOT IN(Select ORDER_NUMBER FROM V5_MC_App_Order_Split_Bookings_Adjustments) ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<oracle_n_vias>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
