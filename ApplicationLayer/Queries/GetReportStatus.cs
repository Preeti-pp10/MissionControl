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
    public class GetReportStatus : IRequest<IList<ReportStatus>>
    {
        public class GetReportStatusHandler : IRequestHandler<GetReportStatus, IList<ReportStatus>>
        {
            private readonly IConfiguration _configuration;
            public GetReportStatusHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<ReportStatus>> Handle(GetReportStatus request, CancellationToken cancellationToken)
            {

                var sql = "select curr.Forecast_Year_Period, curr.Reported_Forecast_Period, curr.Forecast_Quarter,curr.Active, nxt.ID,IsNull(nxt.Prelim_Forecast_Year_Period, curr.Prelim_Forecast_Year_Period) As Prelim_Forecast_Year_Period from V5_MC_App_Report_Status as curr left join V5_MC_App_Report_Status as nxt on curr.ID = nxt.ID - 1 Where curr.Active = 1";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<ReportStatus>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
