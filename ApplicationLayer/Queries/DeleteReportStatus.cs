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
    public class DeleteReportStatus : IRequest<int>
    {
        public class DeleteReportStatusHandler : IRequestHandler<DeleteReportStatus, int>
        {
            private readonly IConfiguration _configuration;
            public DeleteReportStatusHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(DeleteReportStatus request, CancellationToken cancellationToken)
            {
                var sql = "DELETE FROM V5_MC_App_sbodb_report_status WHERE Forecast_Status = 'final' ";
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
