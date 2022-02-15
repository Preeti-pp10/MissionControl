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
    public class DeactiveUpdatePeriod : IRequest<int>
    {
        public class DeactiveUpdatePeriodHandler : IRequestHandler<DeactiveUpdatePeriod, int>
        {
            private readonly IConfiguration _configuration;
            public DeactiveUpdatePeriodHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(DeactiveUpdatePeriod command, CancellationToken cancellationToken)
            {
                var sql = "Update V5_MC_App_Update_Report_Period Set active= '' Where active =1 ";
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
