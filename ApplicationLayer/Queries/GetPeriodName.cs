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
    public class GetPeriodName : IRequest<IList<ReportPeriodModel>>
    {
        public class GetPeriodNameHandler : IRequestHandler<GetPeriodName, IList<ReportPeriodModel>>
        {
            private readonly IConfiguration _configuration;
            public GetPeriodNameHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<ReportPeriodModel>> Handle(GetPeriodName request, CancellationToken cancellationToken)
            {
                var sql = "select IsNull(nxt.TRANS_DATE_PERIOD_NAME, curr.TRANS_DATE_PERIOD_NAME)As TRANS_DATE_PERIOD_NAME from V5_MC_App_Update_Report_Period as curr left join V5_MC_App_Update_Report_Period as nxt on curr.Id = nxt.Id - 1 Where curr.Active = 1";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<ReportPeriodModel>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
