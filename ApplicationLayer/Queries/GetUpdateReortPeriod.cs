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
    public class GetUpdateReortPeriod : IRequest<IList<ReportPeriodModel>>
    {
        public class GetUpdateReortPeriodHandler : IRequestHandler<GetUpdateReortPeriod, IList<ReportPeriodModel>>
        {
            private readonly IConfiguration _configuration;
            public GetUpdateReortPeriodHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<ReportPeriodModel>> Handle(GetUpdateReortPeriod request, CancellationToken cancellationToken)
            {
                var sql = "select * from V5_MC_App_Update_Report_Period where Active=1";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<ReportPeriodModel>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
