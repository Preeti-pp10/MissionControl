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
    public class ReportPeriodAudit : IRequest<int>
    {
            public string report_year_quarter { get; set;}
            public string report_period { get; set; }
            public string report_year_period { get; set; }
            public string Created_By { get; set; } = System.Environment.MachineName;
            public DateTime UpdateDate { get; set; } = DateTime.Now;        

        public class ReportPeriodAuditHandler : IRequestHandler<ReportPeriodAudit, int>
        {
            private readonly IConfiguration _configuration;

            public ReportPeriodAuditHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<int> Handle(ReportPeriodAudit command, CancellationToken cancellationToken)
            {
                var sql = " Insert Into V5_MC_App_Report_Period_Audit (report_year_quarter,report_period,report_year_period,Created_By,UpdateDate) Values (@report_year_quarter,@report_period,@report_year_period,@Created_By,@UpdateDate) ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, new { command.report_year_quarter, command.report_period, command.report_year_period, command.Created_By, command.UpdateDate });
                    return result;
                }   
            }
        }
    }
}
