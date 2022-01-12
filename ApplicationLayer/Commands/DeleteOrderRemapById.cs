using Dapper;
using DomainLayer;
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
    public class DeleteOrderRemapById : IRequest<IList<OrderRemap>>
    {
        [Required]
        public int ID { get; set; }
        public class DeleteOrderRemapByIdHandler : IRequestHandler<DeleteOrderRemapById, IList<OrderRemap>>
        {
            private readonly IConfiguration _configuration;
            public DeleteOrderRemapByIdHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<OrderRemap>> Handle(DeleteOrderRemapById command, CancellationToken cancellationToken)
            {
                var sql = "DELETE FROM Order_Remap WHERE ID = @ID";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<OrderRemap>(sql, new { ID = command.ID });
                    return result.ToList();
                }
            }


        }
    }
}
