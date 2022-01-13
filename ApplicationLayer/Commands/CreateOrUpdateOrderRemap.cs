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
    public class CreateOrUpdateOrderRemap : IRequest<int>
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
        public bool Is_Anaplan_TQM { get; set; }
        public bool Is_Approved_Move_To_New_Region { get; set; }
        public class CreateOrUpdateOrderRemapHandler : IRequestHandler<CreateOrUpdateOrderRemap, int>
        {
            private readonly IConfiguration _configuration;
            public CreateOrUpdateOrderRemapHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(CreateOrUpdateOrderRemap command, CancellationToken cancellationToken)
            {
                var result = 0;
                try
                {
                    if (command.ID > 0)
                    {
                        var sql = "Update Order_Remap set ORDER_NUMBER =@ORDER_NUMBER,PO_NUMBER =@PO_NUMBER,REGION=@REGION,SUB_REGION=@SUB_REGION,DISTRICT=@DISTRICT,New_Region=@New_Region,New_Subregion=@New_Subregion,New_District= @New_District,Period=@Period,Start_Quarter=@Start_Quarter,Method=@Method,Standard_Reason=@Standard_Reason,Comments=@Comments,Is_Anaplan_TQM=@Is_Anaplan_TQM, Is_Approved_Move_To_New_Region=@Is_Approved_Move_To_New_Region Where ID =@ID";
                        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                        {
                            connection.Open();
                            result = await connection.ExecuteAsync(sql,command);
                            return result;
                        }
                    }
                    else
                    {
                        var sql = "Insert into Order_Remap (ORDER_NUMBER,PO_NUMBER,REGION,SUB_REGION,DISTRICT,New_Region,New_Subregion,New_District,Period,Start_Quarter,Method,Standard_Reason,Comments,Is_Anaplan_TQM,Is_Approved_Move_To_New_Region) VALUES ( @ORDER_NUMBER,@PO_NUMBER,@REGION,@SUB_REGION,@DISTRICT,@New_Region,@New_Subregion,@New_District,@Period,@Start_Quarter,@Method,@Standard_Reason,@Comments,@Is_Anaplan_TQM,@Is_Approved_Move_To_New_Region)";
                        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                        {
                            connection.Open();
                            result = await connection.ExecuteAsync(sql, new { command.ORDER_NUMBER, command.PO_NUMBER, command.REGION, command.SUB_REGION, command.DISTRICT, command.New_Region, command.New_Subregion, command.New_District, command.Period, command.Start_Quarter, command.Method, command.Standard_Reason, command.Comments, command.Is_Anaplan_TQM, command.Is_Approved_Move_To_New_Region});
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return result;
                }
            }
      
    
        }
    }
}
