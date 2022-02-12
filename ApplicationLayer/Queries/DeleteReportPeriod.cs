using Dapper;
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
    public class DeleteReportPeriod : IRequest<int>
    {
        public class DeleteReportPeriodHandler : IRequestHandler<DeleteReportPeriod, int>
        {
            private readonly IConfiguration _configuration;
            public DeleteReportPeriodHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(DeleteReportPeriod request, CancellationToken cancellationToken)
            {
                var sql = "DELETE FROM V5_MC_App_sbodw_report_period WHERE Active = 1";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql);
                    return result;
                }
            }
        }
    }
}
