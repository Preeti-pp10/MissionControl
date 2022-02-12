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
    public class GetStartQuarter :IRequest<IList<FunnelCoverage>>
    {
        public class GetStartQuarterHandler : IRequestHandler<GetStartQuarter, IList<FunnelCoverage>>
        {
            private readonly IConfiguration _configuration;
            public GetStartQuarterHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<FunnelCoverage>> Handle(GetStartQuarter request, CancellationToken cancellationToken)
            {
                var sql = "SELECT   min(year_quarter)  from (select top 3 year_quarter from dwh_periods where YEAR_QUARTER < (select [report_year_quarter] from[V5_MC_App_sbodw_report_period]) group by YEAR_QUARTER order by YEAR_QUARTER desc) as main";
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
