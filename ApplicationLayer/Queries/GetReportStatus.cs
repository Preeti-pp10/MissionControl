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

                var sql = "select t1.Forecast_Year_Period, t1.Reported_Forecast_Period,t1.Forecast_Quarter, t2.Prelim_Forecast_Year_Period from V5_MC_App_Report_Status t1,V5_MC_App_Report_Status t2 where t1.ID = 84 and t2.Prelim_Forecast_Year_Period = '2022-11'";
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
