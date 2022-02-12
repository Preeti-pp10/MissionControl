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
    public class GetNextForecastQuarter : IRequest<IList<FunnelCoverage>>
    {
        public class GetNextForecastQuarterHandler : IRequestHandler<GetNextForecastQuarter, IList<FunnelCoverage>>
        {
            private readonly IConfiguration _configuration;
            public GetNextForecastQuarterHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<FunnelCoverage>> Handle(GetNextForecastQuarter request, CancellationToken cancellationToken)
            {
                var sql = "(select [report_year_quarter] from [V5_MC_App_sbodw_report_period]) +  '-'  + (select  case when(select m3  from [V5_MC_App_sbodb_report_status]) = report_period  then 'M3' else 'M1' end FROM[V5_MC_App_sbodw_report_period])";
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
