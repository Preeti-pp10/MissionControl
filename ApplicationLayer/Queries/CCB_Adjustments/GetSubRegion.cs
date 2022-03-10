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
    public class GetSubRegion : IRequest<IList<oracle_n_vias>>
    {
        public string Region { get; set; }
        public class GetSubRegionHandler : IRequestHandler<GetSubRegion, IList<oracle_n_vias>>
        {
            private readonly IConfiguration _configuration;

            public GetSubRegionHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<oracle_n_vias>> Handle(GetSubRegion query, CancellationToken cancellationToken)
            {
                var sql = " SELECT Distinct SubRegion FROM  sbodw_V5_Sales_Leader_Hierarchy_v Where Region = @Region ORDER BY SubRegion";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<oracle_n_vias>(sql , new { Region  = query.Region });
                    return result.ToList();
                }
            }
        }
    }
}
