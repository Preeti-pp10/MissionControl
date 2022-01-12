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
     public class GetStandarReasonQuery : IRequest<IList<StandardMethodModel>>
    {
        public class GetStandarReasonQueryHandler : IRequestHandler<GetStandarReasonQuery, IList<StandardMethodModel>>
        {
            private readonly IConfiguration _configuration;
            public GetStandarReasonQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<StandardMethodModel>> Handle(GetStandarReasonQuery request, CancellationToken cancellationToken)
            {
                var sql = "Select Id,Standdard_Reason from Standard_Reasons";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<StandardMethodModel>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
