using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.CCB.oracle_n_vias;

namespace ApplicationLayer.Commands.CCB_Adjustments
{
    public class CreateCustomCommand : IRequest<int>
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
        public string TRANSCATION { get; set; }
        public string ENTRY_BY { get; set; }
        public DateTime ENTRY_DATE { get; set; }
        public string SPLIT_TYPE { get; set; }

        public class CreateCustomCommandHandler : IRequestHandler<CreateCustomCommand, int>
        {
            private readonly IConfiguration _configuration;

            public CreateCustomCommandHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(CreateCustomCommand command, CancellationToken cancellationToken)
            {

                var sql = " INSERT INTO V5_MC_App_Order_Split_Bookings_Adjustments(TRANSCATION,ORDER_NUMBER,DISTRICT,FISCAL_PERIOD,L3_BUSINESS_GROUP,L4_BUSINESS_UNIT,L5_PRODUCT_LINE,TRANS_DATE,BOOKINGS,COMMENTS,CC_AMT_GROSS_BOOKINGS,SPLIT_PERCENT,ENTRY_DATE,ENTRY_BY,SPLIT_TYPE,REGION,SUB_REGION)VALUES(@TRANSCATION,@ORDER_NUMBER,@DISTRICT,@FISCAL_PERIOD,@L3_BUSINESS_GROUP,@L4_BUSINESS_UNIT,@L5_PRODUCT_LINE,@TRANS_DATE,@BOOKINGS,@COMMENTS,@CC_AMT_GROSS_BOOKINGS,@SPLIT_PERCENT,@ENTRY_DATE,@ENTRY_BY,@SPLIT_TYPE,@REGION,@SUB_REGION) ";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, new { command.TRANSCATION, command.ORDER_NUMBER, command.REGION, command.SUB_REGION, command.DISTRICT, command.FISCAL_PERIOD, command.L3_BUSINESS_GROUP, command.L4_BUSINESS_UNIT, command.L5_PRODUCT_LINE, command.TRANS_DATE, command.CC_AMT_GROSS_BOOKINGS, command.BOOKINGS, command.COMMENTS, command.ENTRY_BY, command.ENTRY_DATE, command.SPLIT_PERCENT, command.SPLIT_TYPE });
                    return result;
                    }
            }
        }
    }
}
