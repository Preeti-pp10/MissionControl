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
    public class UpdateReportStatus :IRequest<int>
    {
        public int ID { get; set; }
        public string Active { get; set; }

        public class UpdateReportStatusHandler : IRequestHandler<UpdateReportStatus, int>
        {
            private readonly IConfiguration _configuration;
            public UpdateReportStatusHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(UpdateReportStatus command, CancellationToken cancellationToken)
            {
                if(command.ID >0)
                {
                    var sql = "update V5_MC_App_Report_Status set Active='1' where ID=@ID";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, command);
                        return result;
                    }

                }
                else
                {
                    return 0;

                }
            }
        }
    }
}
