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
    public class UpdatePeriodCommand : IRequest<int>
    {
        public string TRANS_DATE_PERIOD_NAME { get; set; }

        public class UpdatePeriodCommandHandler : IRequestHandler<UpdatePeriodCommand, int>
        {
                private readonly IConfiguration _configuration;
                public UpdatePeriodCommandHandler(IConfiguration configuration)
                {
                    _configuration = configuration;
                }
            public async Task<int> Handle(UpdatePeriodCommand command, CancellationToken cancellationToken)
            {
              
                var sql = "update V5_MC_App_Update_Report_Period set Active = '1' Where TRANS_DATE_PERIOD_NAME = @TRANS_DATE_PERIOD_NAME";
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
