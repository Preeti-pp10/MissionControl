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

namespace ApplicationLayer
{
    public class CCBDataLayer : IRequest<int>
    {
        
        public string ORDER_NUMBER { get; set; }
        public string REGION { get; set; }
        public string SUB_REGION { get; set; }
        public string PO_NUMBER { get; set; }
        public string DISTRICT { get; set; }
        public string L3_BUSINESS_GROUP { get; set; }
        public string L4_BUSINESS_UNIT { get; set; }
        public string L5_PRODUCT_LINE { get; set; }
        public string TRANS_DATE_PERIOD_NAME { get; set; }
        public decimal CC_AMT_GROSS_BOOKINGS { get; set; }
        public DateTime TRANS_DATE { get; set; }
        public string SPLIT_PERCENT { get; set; }
        public decimal BOOKINGS { get; set; }
        public string FISCAL_PERIOD { get; set; }
        public string COMMENTS { get; set; }
        public string TRANSCATION { get; set; } = Guid.NewGuid().ToString();
        public string ENTRY_BY { get; set; } = System.Environment.MachineName;
        public DateTime ENTRY_DATE { get; set; } = DateTime.UtcNow;
        public string SPLIT_TYPE { get; set; } = "Custome Split";
        public class CCBDataLayerHandler : IRequestHandler<CCBDataLayer,int>
        {
            private readonly IConfiguration _configuration;

            public CCBDataLayerHandler(IConfiguration configuration )
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(CCBDataLayer command, CancellationToken cancellationToken)
            {
                var sql = " Insert into V5_MC_App_Order_Split_Bookings_Adjustments (TRANSCATION, ORDER_NUMBER, DISTRICT, FISCAL_PERIOD, L3_BUSINESS_GROUP, L4_BUSINESS_UNIT, L5_PRODUCT_LINE, TRANS_DATE, BOOKINGS, COMMENTS, CC_AMT_GROSS_BOOKINGS, SPLIT_PERCENT, ENTRY_DATE, ENTRY_BY, SPLIT_TYPE, REGION, SUB_REGION) VALUES (@TRANSCATION,@ORDER_NUMBER,@DISTRICT,@FISCAL_PERIOD,@L3_BUSINESS_GROUP,@L4_BUSINESS_UNIT,@L5_PRODUCT_LINE,@TRANS_DATE,@BOOKINGS,@COMMENTS,@CC_AMT_GROSS_BOOKINGS,@SPLIT_PERCENT,@ENTRY_DATE,@ENTRY_BY,@SPLIT_TYPE,@REGION,@SUB_REGION) ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql,  new { command.ORDER_NUMBER, command.TRANSCATION, command.DISTRICT, command.FISCAL_PERIOD, command.L3_BUSINESS_GROUP, command.L4_BUSINESS_UNIT, command.L5_PRODUCT_LINE, command.TRANS_DATE, command.BOOKINGS, command.COMMENTS, command.CC_AMT_GROSS_BOOKINGS, command.SPLIT_PERCENT, command.ENTRY_DATE, command.ENTRY_BY, command.SPLIT_TYPE, command.REGION, command.SUB_REGION  }); ;
                    return result;
                }
            }
        }

    }
}
