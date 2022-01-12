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

namespace ApplicationLayer.Queries
{
    public class GetOrderRemapById : IRequest<IList<OrderRemap>>
    {
        [Required]
        public int ID { get; set; }
        public class GetOrderRemapByIdHandler : IRequestHandler<GetOrderRemapById, IList<OrderRemap>>
        {
            private readonly IConfiguration _configuration;
            public GetOrderRemapByIdHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<OrderRemap>> Handle(GetOrderRemapById query, CancellationToken cancellationToken)
            {
                var sql = "Select ID,ORDER_NUMBER,PO_NUMBER,REGION,SUB_REGION,DISTRICT,New_Region,New_Subregion,New_District,Period,Start_Quarter,Method,Standard_Reason,Comments,Is_Anaplan_TQM,Is_Approved_Move_To_New_Region From Order_Remap Where ID=@ID";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<OrderRemap>(sql, new { ID = query.ID });
                    return result.ToList();
                }
            }


        }

    }
}
