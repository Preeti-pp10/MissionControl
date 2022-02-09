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
    public class FunnelCoverageAudit : IRequest<int>
    {
        public int ID { get; set; }
        public string Current_Quarter { get; set; }
        public string Start_Quarter { get; set; }
        public string End_Quarter { get; set; }
        public string Forecast_Month { get; set; }
        public string Num_Qtrs { get; set; }
        public string FCST_YQ_M { get; set; }
        public string User { get; set; } = System.Environment.MachineName;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string Type { get; set; } = "Update";

        public class FunnelCoverageAuditHandler : IRequestHandler<FunnelCoverageAudit, int>
        {
            private readonly IConfiguration _configuration;
            public FunnelCoverageAuditHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(FunnelCoverageAudit command, CancellationToken cancellationToken)
            {
                try
                {
                    var sql = "Insert into V5_MC_App_Config_Funnel_Coverage_Audit (Current_Quarter,Start_Quarter,End_Quarter,Forecast_Month,Num_Qtrs,FCST_YQ_M,User,UpdateDate,Type) VALUES (@Current_Quarter,@Start_Quarter,@End_Quarter,@Forecast_Month,@Num_Qtrs,@FCST_YQ_M,@User,@UpdateDate,@Type)";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, new { command.Current_Quarter, command.Start_Quarter, command.End_Quarter, command.Forecast_Month, command.Num_Qtrs, command.FCST_YQ_M, command.Type, command.User, command.UpdateDate });
                        return result;
                    }
                }
                catch (Exception e)
                {

                    throw e;
                }

               
            }
        }
    }
}
