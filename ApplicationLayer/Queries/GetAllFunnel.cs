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
    public class GetAllFunnel : IRequest<IList<FunnelCoverage>>
    {

        public class GetAllFunnelHandler : IRequestHandler<GetAllFunnel, IList<FunnelCoverage>>
        {
            private readonly IConfiguration _configuration;
            public GetAllFunnelHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<FunnelCoverage>> Handle(GetAllFunnel query, CancellationToken cancellationToken)
            {

                var sql = "SELECT ID,Current_Quarter,Start_Quarter,End_Quarter,Forecast_Month,Num_Qtrs,FCST_YQ_M From V5_MC_App_Config_Funnel_Coverage";
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
