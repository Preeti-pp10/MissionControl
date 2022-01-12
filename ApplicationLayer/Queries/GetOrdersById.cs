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
    public class GetOrdersById : IRequest<IList<OrderModel>>
    {
        [Required]
        public  int Id { get; set; }
        public class GetOrdersByIdHandler : IRequestHandler<GetOrdersById, IList<OrderModel>>
        {
            private readonly IConfiguration _configuration;
            public GetOrdersByIdHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<OrderModel>> Handle(GetOrdersById query, CancellationToken cancellationToken)
            {
                var sql = "Select Id,ORDER_NUMBER,PO_NUMBER,TRANS_DATE_YEAR_QUARTER,TRANS_DATE_PERIOD_NAME,REGION,SUB_REGION,DISTRICT From Orders Where Id=@Id";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<OrderModel>(sql,new {Id = query.Id});
                    return result.ToList();
                }
            }
        }
    }
}
