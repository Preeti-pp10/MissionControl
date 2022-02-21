using Dapper;
using DomainLayer.CCB;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Queries.CCB_Adjustments
{
    public class GetSalesLeader :IRequest< IList<oracle_n_vias>>
    {
       
        public class GetSalesLeaderHandler : IRequestHandler<GetSalesLeader, IList<oracle_n_vias>>
        {
            private readonly IConfiguration _configuration;

            public GetSalesLeaderHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<oracle_n_vias>> Handle(GetSalesLeader query, CancellationToken cancellationToken)
            {
                var sql = " SELECT DISTINCT [Sales_Leader]  FROM  sbodw_V5_Sales_Leader_Hierarchy_v ORDER BY[Sales_Leader] ";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<oracle_n_vias>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
