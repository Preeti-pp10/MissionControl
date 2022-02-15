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
    public class GetNextForecastMonth : IRequest<IList<FunnelCoverage>>
    {
        public class GetNextForecastMonthHandler : IRequestHandler<GetNextForecastMonth, IList<FunnelCoverage>>
        {
            private readonly IConfiguration _configuration;
            public GetNextForecastMonthHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IList<FunnelCoverage>> Handle(GetNextForecastMonth request, CancellationToken cancellationToken)
            {
                var sql = "Select case  when (select m3 FROM [V5_MC_App_sbodb_report_status]) = report_period then 'M3' else 'M1' end as Forecast_Month from [V5_MC_App_sbodw_report_period]";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<FunnelCoverage>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
