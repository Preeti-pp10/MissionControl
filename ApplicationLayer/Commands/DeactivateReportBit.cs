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
    public class DeactivateReportBit : IRequest<int>
    {

        public class DeactivateReportBitHandler : IRequestHandler<DeactivateReportBit, int>
        {
            private readonly IConfiguration _configuration;
            public DeactivateReportBitHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(DeactivateReportBit command, CancellationToken cancellationToken)
            {
            
                    var sql = "update V5_MC_App_Report_Status set Active= '' where Active=1 ";
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
