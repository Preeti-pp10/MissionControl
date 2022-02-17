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
    public class ReportStatusAudit : IRequest<int>
    {
        public string Forecast_Quarter { get; set; }
        public string Forecast_Year_Period { get; set; }
        public string Reported_Forecast_Period { get; set; }
        public string Created_By { get; set; } = System.Environment.MachineName;
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public class ReportStatusAuditHandler : IRequestHandler<ReportStatusAudit, int>
        {
            private readonly IConfiguration _configuration;

            public ReportStatusAuditHandler(IConfiguration configuration) 
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(ReportStatusAudit command, CancellationToken cancellationToken)
            {
                var sql = " Insert Into V5_MC_App_Report_Status_Audit (Forecast_Quarter,Forecast_Year_Period,Reported_Forecast_Period,Created_By,UpdateDate) Values (@Forecast_Quarter,@Forecast_Year_Period,@Reported_Forecast_Period,@Created_By,@UpdateDate) ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, new { command.Forecast_Quarter, command.Forecast_Year_Period, command.Reported_Forecast_Period, command.Created_By, command.UpdateDate });
                    return result;
                }
            }
        }

    }
}
