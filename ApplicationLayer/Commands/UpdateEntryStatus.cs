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
    public class UpdateEntryStatus : IRequest<int>
    {
        public int ID { get; set; }
        public string Forecast_Status {get; set;}
        public string Forecast_Year_Period { get; set; }
        public string Forecast_Year_Last_Period { get; set; }
        public string Reported_Forecast_Year_Period { get; set; }
        public string Reported_Forecast_Period { get; set; }
        public string M1 { get; set; }
        public string M2 { get; set; }
        public string M3 { get; set; }
        public string Forecast_Quarter { get; set; }
        public string Last_Quarter { get; set; }
        public string NM1 { get; set; }
        public string NM2 { get; set; }
        public string NM3 { get; set; }
        public string Next_Quarter { get; set; }
        public string Prelim_Forecast_Year_Period { get; set; }
        public class UpdateEntryStatusHandler : IRequestHandler<UpdateEntryStatus, int>
        {
            private readonly IConfiguration _configuration;
            public UpdateEntryStatusHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(UpdateEntryStatus command, CancellationToken cancellationToken)
            {
                var SQL = "Insert into V5_MC_App_sbodb_report_status (ID,Forecast_Status,Forecast_Year_Period,Forecast_Year_Last_Period,Reported_Forecast_Year_Period,Reported_Forecast_Period,M1, M2,M3,Forecast_Quarter,Last_Quarter,NM1,NM2, NM3,Next_Quarter,Prelim_Forecast_Year_Period)Select ID,Forecast_Status,Forecast_Year_Period, Forecast_Year_Last_Period,Reported_Forecast_Year_Period,Reported_Forecast_Period,M1,M2,M3, Forecast_Quarter, Last_Quarter,NM1,NM2, NM3,Next_Quarter,Prelim_Forecast_Year_Period from V5_MC_App_Report_Status Where Active = 1";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(SQL, new
                    {
                        command.ID,
                        command.Forecast_Status,
                        command.Forecast_Year_Period,
                        command.Forecast_Year_Last_Period,
                        command.Reported_Forecast_Period,
                        command.Reported_Forecast_Year_Period,
                        command.M1,
                        command.M2,
                        command.M3,
                        command.Forecast_Quarter,
                        command.Last_Quarter,
                        command.NM1,
                        command.NM2,
                        command.NM3,
                        command.Next_Quarter,
                        command.Prelim_Forecast_Year_Period
                    });
                    return result;
                }
            }
        }
    }
}
