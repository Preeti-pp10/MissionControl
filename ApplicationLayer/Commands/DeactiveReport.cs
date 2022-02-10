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
    public class DeactivateReport : IRequest<int>
    {

        public class DeactivateReportHandler : IRequestHandler<DeactivateReport, int>
        {
            private readonly IConfiguration _configuration;
            public DeactivateReportHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(DeactivateReport command, CancellationToken cancellationToken)
            {

                var sql = "update V5_MC_App_Report_Period set Active= '' where Active=1 ";
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
