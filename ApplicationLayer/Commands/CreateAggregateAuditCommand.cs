using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands
{
    public class CreateAggregateAuditCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string customer { get; set; }
        public string aggregated_customer { get; set; }
        [DataType(DataType.Date)]
        public DateTime? entry_date { get; set; }
        public DateTime created_on { get; set; } = DateTime.Now;
        public string created_by { get; set; } = System.Environment.MachineName;
        public string Type { get; set; } = "Created";

        public class CreateAggregateAuditCommandHandler : IRequestHandler<CreateAggregateAuditCommand, int>
        {
            private readonly IConfiguration _configuration;
            public CreateAggregateAuditCommandHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(CreateAggregateAuditCommand command, CancellationToken cancellationToken)
            {
                if(command.Id == 0)
                {
                    var sql = "Insert into MC_App_Customer_Aggregation_Audit (customer,aggregated_customer,entry_date,created_on,created_by,Type) VALUES ( @customer,@aggregated_customer,@entry_date,@created_on,@created_by,@Type)";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, new { command.customer, command.aggregated_customer, command.entry_date, command.Type,command.created_on, command.created_by});
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
