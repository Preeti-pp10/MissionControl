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
    public class FunnelCoverageCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Current_Quarter { get; set; }
        public string Start_Quarter { get; set; }
        public string End_Quarter { get; set; }
        public string Forecast_Month { get; set; }
        public string Num_Qtrs { get; set; }
        public string FCST_YQ_M { get; set; }

        public class FunnelCoverageCommandHandler : IRequestHandler<FunnelCoverageCommand, int>
        {
            private readonly IConfiguration _configuration;
            public FunnelCoverageCommandHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<int> Handle(FunnelCoverageCommand command, CancellationToken cancellationToken)
            {
                if (command.ID > 0)
                {
                    var sql = "UPDATE V5_MC_App_Config_Funnel_Coverage SET Current_Quarter = @Current_Quarter, Start_Quarter = @Start_Quarter, End_Quarter = @End_Quarter, Forecast_Month = @Forecast_Month, Num_Qtrs = @Num_Qtrs, FCST_YQ_M = @FCST_YQ_M Where ID = @ID";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, command);
                        return result;
                    }

                }
                else
                {
                    var sql = "Insert into V5_MC_App_Config_Funnel_Coverage (Current_Quarter,Start_Quarter,End_Quarter,Forecast_Month,Num_Qtrs,FCST_YQ_M) VALUES (@Current_Quarter,@Start_Quarter,@End_Quarter,@Forecast_Month,@Num_Qtrs,@FCST_YQ_M)";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, new { command.Current_Quarter, command.Start_Quarter, command.End_Quarter, command.Forecast_Month, command.Num_Qtrs, command.FCST_YQ_M });
                        return result;
                    }

                }
            }
        }

    }
}
