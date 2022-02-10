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
    public class UpdateReportPeriod : IRequest<int>
    {
        public string report_period { get; set; }

        public class UpdateReportPeriodHandler : IRequestHandler<UpdateReportPeriod, int>
        {
            private readonly IConfiguration _configuration;
            public UpdateReportPeriodHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(UpdateReportPeriod command, CancellationToken cancellationToken)
            {
                    var sql = "update V5_MC_App_Report_Period set Active='1'  Where report_period= @report_period";
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
