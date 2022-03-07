using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {


        [HttpGet]
        public ActionResult GetOrders()
        {
            MissionControlContext context = new MissionControlContext();    
            return Ok(context.V6DwhBookingsOracleNVias);
        }


        [HttpGet(nameof(GetById))]
        public ActionResult<V6DwhBookingsOracleNVia> GetById( string OrderNumber)
        {
            MissionControlContext context = new MissionControlContext();
            return Ok(context.V6DwhBookingsOracleNVias.Where( order => order.OrderNumber == OrderNumber).ToList());  
        }


        [HttpPost]
        public ActionResult Insert(List<V5McAppOrderSplitBookingsAdjustment> v6Dwhs)
        {
            using( MissionControlContext context = new MissionControlContext())
            {

               if( v6Dwhs == null)
                {
                    v6Dwhs = new List<V5McAppOrderSplitBookingsAdjustment>();
                }
                foreach (V5McAppOrderSplitBookingsAdjustment customer in v6Dwhs)
                {
                    context.Add(customer);
                }
                int insertedRecords = context.SaveChanges();
                return Ok(insertedRecords);

            }
        }
    }
}
