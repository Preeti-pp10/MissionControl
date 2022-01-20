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
    public class DeleteAuditData : IRequest<int>
    {
        public int ID { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string PO_NUMBER { get; set; }
        public string Period { get; set; }
        public string Start_Quarter { get; set; }
        public string DISTRICT { get; set; }
        public string SUB_REGION { get; set; }
        public string REGION { get; set; }
        public string New_Region { get; set; }
        public string New_Subregion { get; set; }
        public string New_District { get; set; }
        public string Method { get; set; }
        public string Standard_Reason { get; set; }
        public string Comments { get; set; }
        public string Remap_Type { get; set; } = "Deleted";
        public string Remap_Person { get; set; } = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
        public DateTime Remap_Date { get; set; } = DateTime.Now;
        public bool Is_Anaplan_TQM { get; set; }
        public bool Is_Approved_Move_To_New_Region { get; set; }
        public bool Is_Active { get; set; } = true;
        public class DeleteAuditDataHandler : IRequestHandler<DeleteAuditData, int>
        {
            private readonly IConfiguration _configuration;
            public DeleteAuditDataHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(DeleteAuditData command, CancellationToken cancellationToken)
            {
                
                    var sql = "Insert into Order_Audit (ORDER_NUMBER,PO_NUMBER,REGION,SUB_REGION,DISTRICT,New_Region,New_Subregion,New_District,Period,Start_Quarter,Method,Standard_Reason,Comments,Is_Anaplan_TQM,Is_Approved_Move_To_New_Region,Remap_Date,Is_Active, Remap_Person,Remap_Type) VALUES ( @ORDER_NUMBER,@PO_NUMBER,@REGION,@SUB_REGION,@DISTRICT,@New_Region,@New_Subregion,@New_District,@Period,@Start_Quarter,@Method,@Standard_Reason,@Comments,@Is_Anaplan_TQM,@Is_Approved_Move_To_New_Region,@Remap_Date,@Is_Active,@Remap_Person,@Remap_Type)";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, new { command.ORDER_NUMBER, command.PO_NUMBER, command.REGION, command.SUB_REGION, command.DISTRICT, command.New_Region, command.New_Subregion, command.New_District, command.Period, command.Start_Quarter, command.Method, command.Standard_Reason, command.Comments, command.Is_Anaplan_TQM, command.Is_Approved_Move_To_New_Region, command.Remap_Date, command.Is_Active, command.Remap_Person, command.Remap_Type });
                        return result;
                    }


            }
        }
    }
}
