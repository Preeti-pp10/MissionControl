using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands
{
    public class UpdateEntryPeroid : IRequest<int>
    {
        public int report_year { get; set; }
        public string report_year_quarter { get; set; }
        public string report_period { get; set; }
        public string report_year_period { get; set; }
        public string last_report_period { get; set; }
        public string last_report_year_quarter { get; set; }
        public int last_report_year { get; set; }
        public string last_report_year_period { get; set; }
        public string last_year_report_year_quarter { get; set; }
        public string next_report_year_quarter { get; set; }
        public string next_report_period { get; set; }
        public string last_year_last_report_quarter { get; set; }
        public string next_year_report_year_quarter { get; set; }
        public string last_year_report_year_period { get; set; }
        public string last_quarter_report_year_period { get; set; }
        public string Active { get; set; }

        public class UpdateEntryPeroidHandler : IRequestHandler<UpdateEntryPeroid, int>
        {
            private readonly IConfiguration _configuration;
            public UpdateEntryPeroidHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(UpdateEntryPeroid command, CancellationToken cancellationToken)
            {
              
                var SQL = "INSERT INTO V5_MC_App_sbodw_report_period(report_year, report_year_quarter, report_period, report_year_period, last_report_period,last_report_year_quarter, last_report_year, last_report_year_period, last_year_report_year_quarter,next_report_year_quarter, next_report_period, last_year_last_report_quarter, next_year_report_year_quarter,last_year_report_year_period, last_quarter_report_year_period, Active) SELECT report_year, report_year_quarter, report_period, report_year_period, last_report_period, last_report_year_quarter, last_report_year, last_report_year_period, last_year_report_year_quarter,next_report_year_quarter, next_report_period, last_year_last_report_quarter, next_year_report_year_quarter,last_year_report_year_period, last_quarter_report_year_period, Active FROM V5_MC_App_Report_Period Where Active = 1";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(SQL, new {
                        command.report_year,
                        command.report_year_quarter,
                        command.report_period,
                        command.report_year_period,
                        command.last_report_period,
                        command.last_report_year_quarter,
                        command.last_report_year,
                        command.last_report_year_period,
                        command.last_year_report_year_quarter,
                        command.next_report_year_quarter,
                        command.next_report_period,
                        command.last_year_last_report_quarter,
                        command.next_year_report_year_quarter,
                        command.last_year_report_year_period,
                        command.last_quarter_report_year_period,
                        command.Active
                    });
                    return result;
                }
            }
        }
    }
}
