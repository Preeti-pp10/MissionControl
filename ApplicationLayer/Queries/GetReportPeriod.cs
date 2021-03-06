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
    public class GetReportPeriod : IRequest<IList<ReportPeroid>>
    {
        public class GetReportPeriodHandler : IRequestHandler<GetReportPeriod, IList<ReportPeroid>>
        {
            private readonly IConfiguration _configuration;
            public GetReportPeriodHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<ReportPeroid>> Handle(GetReportPeriod request, CancellationToken cancellationToken)
            {
                var sql = "select  curr.report_period, curr.report_year_quarter, curr.report_year_period,curr.Active,IsNull(nxt.report_period, curr.report_period) as report_period from V5_MC_App_Report_Period as curr left join V5_MC_App_Report_Period as nxt on curr.Id = nxt.Id - 1 where curr.Active = 1; ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<ReportPeroid>(sql);
                    return result.ToList();
                }
            }
        }

    }
}
