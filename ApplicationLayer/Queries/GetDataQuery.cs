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
    public class GetDataQuery : IRequest<IList<DataModel>>
    {
        public class GetDataQueryHandler : IRequestHandler<GetDataQuery, IList<DataModel>>
        {
            private readonly IConfiguration _configuration;
            public GetDataQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<DataModel>> Handle(GetDataQuery query, CancellationToken cancellationToken)
            {
                var sql = "Select TRANS_DATE_YEAR_QUARTER,TRANS_DATE_PERIOD_NAME,REGION,SUB_REGION,DISTRICT from Orders";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<DataModel>(sql);
                    return result.ToList();
                }
            }



        }
    }
}
