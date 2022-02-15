using ApplicationLayer.Commands;
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
    public class GetNextCurrentQuarter : IRequest<IList<FunnelCoverage>>
    {

        public class GetNextCurrentQuarterHandler : IRequestHandler<GetNextCurrentQuarter, IList<FunnelCoverage>>
        {
            private readonly IConfiguration _configuration;
            public GetNextCurrentQuarterHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IList<FunnelCoverage>> Handle(GetNextCurrentQuarter request, CancellationToken cancellationToken)
            {
                var sql = " SELECT report_year_quarter  as Current_Quarter from V5_MC_App_sbodw_report_period";
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
