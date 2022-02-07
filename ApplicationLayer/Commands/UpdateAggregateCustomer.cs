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
    public class UpdateAggregateCustomer : IRequest<int>
    {
        public int Id { get; set; }
        public string aggregated_customer { get; set; }
        public DateTime modified_on { get; set; } = DateTime.Now;
        public string modified_by { get; set; } = System.Environment.MachineName;

        public class UpdateAggregateCustomerHandler : IRequestHandler<UpdateAggregateCustomer, int>
        {
            private readonly IConfiguration _configuration;
            public UpdateAggregateCustomerHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<int> Handle(UpdateAggregateCustomer command, CancellationToken cancellationToken)
            { 
                if(command.Id > 0)
                {
                    var sql = "Update MC_App_Customer_Aggregation Set aggregated_customer =@aggregated_customer, modified_on=@modified_on, modified_by =@modified_by Where Id=@Id";
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
