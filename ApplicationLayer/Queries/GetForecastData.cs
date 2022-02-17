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
    public class GetForecastData : IRequest<IList<FunnelCoverage>>
    {
        public class GetForecastDataHandler : IRequestHandler<GetForecastData, IList<FunnelCoverage>>
        {
            private readonly IConfiguration _configuration;
            public GetForecastDataHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<FunnelCoverage>> Handle(GetForecastData request, CancellationToken cancellationToken)
            {
                var sql = "Select * from V5_MC_App_Config_Funnel_Coverage";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<FunnelCoverage >(sql);
                    return result.ToList();
                }
            }
        }
    }
}
