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
    public class GetDistrict : IRequest<IList<oracle_n_vias>>
    {
     
        public string Sales_Team { get; set; }
        public class GetDistrictHandler : IRequestHandler<GetDistrict, IList<oracle_n_vias>>
        {
            private readonly IConfiguration _configuration;

            public GetDistrictHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<oracle_n_vias>> Handle(GetDistrict query, CancellationToken cancellationToken)
            {
                var sql = " SELECT DISTINCT  District  DISTRICT FROM  sbodw_V5_Sales_Leader_Hierarchy_v  Where  Sales_Team = @Sales_Team ORDER BY District ";
               using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<oracle_n_vias>(sql, new { Sales_Team = query.Sales_Team });
                    return result.ToList();
                }
            }
        }
    }
}
