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
    public class CreateOrUpdateCustomers : IRequest<int>
    {
        public int Id { get; set; }
        public string customer { get; set; }
        public string aggregated_customer { get; set; }
        public DateTime? entry_date { get; set; } 
        public DateTime created_on { get; set; }= DateTime.Now;
        public string created_by { get; set; } = System.Environment.MachineName;
        public DateTime modified_on { get; set; } = DateTime.Now;
        public string modified_by { get; set; } = System.Environment.MachineName;

        public class CreateOrUpdateCustomersHandler : IRequestHandler<CreateOrUpdateCustomers, int>
        {
            private readonly IConfiguration _configuration;
            public CreateOrUpdateCustomersHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<int> Handle(CreateOrUpdateCustomers command, CancellationToken cancellationToken)
            {
                if (command.Id > 0)
                {
                    var sql = "Update MC_App_Customer_Aggregation set aggregated_customer =@aggregated_customer, modified_on=@modified_on, modified_by =@modified_by Where Id=@Id";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, command);
                        return result;
                    }

                }
                else
                {
                    var sql = "Insert into MC_App_Customer_Aggregation (customer,aggregated_customer, entry_date, created_on, created_by) VALUES ( @customer,@aggregated_customer,@entry_date, @created_on, @created_by)";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        var result = await connection.ExecuteAsync(sql, new { command.customer, command.aggregated_customer, command.entry_date, command.created_on, command.created_by });
                        return result;
                    }

                }
            }
        }
    }
}
