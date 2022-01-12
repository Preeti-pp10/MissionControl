using Dapper;
using DomainLayer;
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
    public class GetMethodQuery : IRequest<IList<MethodModel>>
    {
        public class GetMethodQueryHandler : IRequestHandler<GetMethodQuery, IList<MethodModel>>
        {
            private readonly IConfiguration _configuration;
            public GetMethodQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<MethodModel>> Handle(GetMethodQuery request, CancellationToken cancellationToken)
            {
                var sql = "Select Id,Method from Methods";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<MethodModel>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
