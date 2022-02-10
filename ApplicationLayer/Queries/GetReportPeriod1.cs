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
    public class GetReportPeriod1 : IRequest<IList<ReportPeroid>>
    {
        public class GetReportPeriod1Handler : IRequestHandler<GetReportPeriod1, IList<ReportPeroid>>
        {
            private readonly IConfiguration _configuration;
            public GetReportPeriod1Handler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<ReportPeroid>> Handle(GetReportPeriod1 request, CancellationToken cancellationToken)
            {
                var sql = "select  nxt.report_period, curr.report_year_quarter, curr.report_year_period,curr.Active,IsNull(curr.report_period, curr.report_period) as report_period from V5_MC_App_Report_Period as curr left join V5_MC_App_Report_Period as nxt on curr.Id = nxt.Id - 1 where curr.Active = 1; ";
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
