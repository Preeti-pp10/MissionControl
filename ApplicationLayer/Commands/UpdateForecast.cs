using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands
{
    public class UpdateForecast : IRequest<int>
    {
        public int ID { get; set; }
        public string Forecast_Month { get; set; }
        public string FCST_YQ_M { get; set; }

        public class UpdateForecastHandler : IRequestHandler<UpdateForecast, int>
        {
            private readonly IConfiguration _configuration;
            public UpdateForecastHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(UpdateForecast command, CancellationToken cancellationToken)
            {
                var sql = "Update V5_MC_App_Config_Funnel_Coverage Set Forecast_Month=@Forecast_Month, FCST_YQ_M = @FCST_YQ_M Where ID=@ID";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, command);
                    return result;
                }
            }
        }
    }
}
