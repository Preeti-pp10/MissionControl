using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Linq;
using WebApplication1.Models;
using System.Transactions;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        MissionControlContext context = new MissionControlContext();
        CCBDataAccessLayer objemployee = new CCBDataAccessLayer();
        [HttpGet]
        public ActionResult GetOrders()
        {
            MissionControlContext context = new MissionControlContext();    
            return Ok(context.V6DwhBookingsOracleNVias);
        }


        [HttpGet(nameof(GetCCb))]
        public ActionResult GetCCb()
        {
            MissionControlContext context = new MissionControlContext();
            var res = context.V6DwhBookingsOracleNVias.Where(c=> !context.V5McAppOrderSplitBookingsAdjustments.Select(b=>b.OrderNumber).Contains(c.OrderNumber));
            return Ok(res);
        }

        [HttpGet(nameof(Getl5))]
        public ActionResult Getl5(string Level3Desc , string Level4Desc)
        {
            MissionControlContext context = new MissionControlContext();
            var res = context.DwhProductHierarchies.Where(l3 => l3.Level3Desc == Level3Desc).Where(l4 => l4.Level4Desc == Level4Desc).Select(l5 => l5.Level5Desc).ToList().Distinct();
            return Ok(res);
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



        [HttpPost(nameof(CustomSplit))]
        public ActionResult CustomSplit(BookingAdjustments bookingAdjustments)
        {
            int res = 0;
            Guid guid = Guid.NewGuid();
            bookingAdjustments.booking.EntryBy = System.Environment.MachineName;
            bookingAdjustments.booking.EntryDate = DateTime.Now;
            bookingAdjustments.booking.SplitType = "Custom Split";
            V5McAppOrderSplitBookingsAdjustment v5McAppOrderSplit = new V5McAppOrderSplitBookingsAdjustment();
            bookingAdjustments.booking.Transcation = guid.ToString();
            v5McAppOrderSplit.OrderNumber = bookingAdjustments.booking.OrderNumber;
            v5McAppOrderSplit.TransDate = bookingAdjustments.booking.TransDate;
            v5McAppOrderSplit.L3BusinessGroup = bookingAdjustments.booking.L3BusinessGroup;
            v5McAppOrderSplit.L4BusinessUnit = bookingAdjustments.booking.L4BusinessUnit;
            v5McAppOrderSplit.L5ProductLine = bookingAdjustments.booking.L5ProductLine;
            v5McAppOrderSplit.CcAmtGrossBookings = bookingAdjustments.booking.Bookings;
            v5McAppOrderSplit.CcAmtGrossBookings = bookingAdjustments.booking.CcAmtGrossBookings;
            v5McAppOrderSplit.Comments = bookingAdjustments.booking.Comments;
            v5McAppOrderSplit.FiscalPeriod = bookingAdjustments.booking.FiscalPeriod;
            v5McAppOrderSplit.SplitType = " Custom Split";
            v5McAppOrderSplit.EntryBy = bookingAdjustments.booking.EntryBy;
            v5McAppOrderSplit.Region = bookingAdjustments.booking.Region;
            v5McAppOrderSplit.District = bookingAdjustments.booking.District;
            v5McAppOrderSplit.SubRegion = bookingAdjustments.booking.SubRegion;
            v5McAppOrderSplit.SplitPercent = "-100";
            v5McAppOrderSplit.Transcation = bookingAdjustments.booking.Transcation;
            v5McAppOrderSplit.Bookings = -1 * bookingAdjustments.booking.CcAmtGrossBookings;
            res = objemployee.InsertCCb(v5McAppOrderSplit);


            if (bookingAdjustments.booking.District1 != null && bookingAdjustments.booking.SplitPercent1 != null && bookingAdjustments.booking.Bookings1 != null)
            {
                v5McAppOrderSplit.Id = 0;
                v5McAppOrderSplit.L5ProductLine = bookingAdjustments.booking.L5ProductLine1;
                v5McAppOrderSplit.District = bookingAdjustments.booking.District1;
                v5McAppOrderSplit.SplitPercent = bookingAdjustments.booking.SplitPercent1;
                v5McAppOrderSplit.Bookings = bookingAdjustments.booking.Bookings1;
                v5McAppOrderSplit.SubRegion = bookingAdjustments.booking.SubRegion1;
                v5McAppOrderSplit.Region = bookingAdjustments.booking.Region1;
                res = objemployee.InsertCCb(v5McAppOrderSplit);


            }
            if (bookingAdjustments.booking.District2 != null && bookingAdjustments.booking.SplitPercent2 != null && bookingAdjustments.booking.Bookings2 != null)
            {
                v5McAppOrderSplit.Id = 0;
                v5McAppOrderSplit.L5ProductLine = bookingAdjustments.booking.L5ProductLine2;
                v5McAppOrderSplit.District = bookingAdjustments.booking.District2;
                v5McAppOrderSplit.SplitPercent = bookingAdjustments.booking.SplitPercent2;
                v5McAppOrderSplit.Bookings = bookingAdjustments.booking.Bookings2;
                v5McAppOrderSplit.SubRegion = bookingAdjustments.booking.SubRegion2;
                v5McAppOrderSplit.Region = bookingAdjustments.booking.Region2;
                res = objemployee.InsertCCb(v5McAppOrderSplit);
            }

            if (bookingAdjustments.booking.District3 != null && bookingAdjustments.booking.SplitPercent3 != null && bookingAdjustments.booking.Bookings3 != null)
            {
                v5McAppOrderSplit.Id = 0;
                v5McAppOrderSplit.District = bookingAdjustments.booking.District3;
                v5McAppOrderSplit.L5ProductLine = bookingAdjustments.booking.L5ProductLine3;
                v5McAppOrderSplit.SplitPercent = bookingAdjustments.booking.SplitPercent3;
                v5McAppOrderSplit.Bookings = bookingAdjustments.booking.Bookings3;
                v5McAppOrderSplit.SubRegion = bookingAdjustments.booking.SubRegion3;
                v5McAppOrderSplit.Region = bookingAdjustments.booking.Region3;
                res = objemployee.InsertCCb(v5McAppOrderSplit);
            }

            if (bookingAdjustments.booking.District4 != null && bookingAdjustments.booking.SplitPercent4 != null && bookingAdjustments.booking.Bookings4 != null)
            {
                v5McAppOrderSplit.Id = 0;
                v5McAppOrderSplit.District = bookingAdjustments.booking.District4;
                v5McAppOrderSplit.L5ProductLine = bookingAdjustments.booking.L5ProductLine4;
                v5McAppOrderSplit.SplitPercent = bookingAdjustments.booking.SplitPercent4;
                v5McAppOrderSplit.Bookings = bookingAdjustments.booking.Bookings4;
                v5McAppOrderSplit.SubRegion = bookingAdjustments.booking.SubRegion4;
                v5McAppOrderSplit.Region = bookingAdjustments.booking.Region4;
                res = objemployee.InsertCCb(v5McAppOrderSplit);
            }


            if (bookingAdjustments.booking.District5 != null && bookingAdjustments.booking.SplitPercent5 != null && bookingAdjustments.booking.Bookings5 != null)
            {
                v5McAppOrderSplit.Id = 0;
                v5McAppOrderSplit.L5ProductLine = bookingAdjustments.booking.L5ProductLine5;
                v5McAppOrderSplit.District = bookingAdjustments.booking.District5;
                v5McAppOrderSplit.SplitPercent = bookingAdjustments.booking.SplitPercent5;
                v5McAppOrderSplit.Bookings = bookingAdjustments.booking.Bookings5;
                v5McAppOrderSplit.SubRegion = bookingAdjustments.booking.SubRegion5;
                v5McAppOrderSplit.Region = bookingAdjustments.booking.Region5;
                res = objemployee.InsertCCb(v5McAppOrderSplit);
            }
            if(res > 0)
            {
                bookingAdjustments.booking.SplitPercent = "100";
                bookingAdjustments.booking.Bookings = bookingAdjustments.booking.CcAmtGrossBookings;
                res = objemployee.InsertCCbAudit(bookingAdjustments.booking);
            }

            return Ok(res);
        }


        [HttpGet(nameof(GetData))]
        public ActionResult GetData()
        {
            var query = (from sba in context.V5McAppOrderSplitBookingsAdjustments 
                         join sbaa in context.V5McAppOrderSplitBookingsAdjustmentsAudits
                         on sba.Transcation equals sbaa.Transcation where sbaa.SplitType == "Custom Split" select sbaa).ToList().Distinct();

            return Ok(query);
        }


        [HttpDelete(nameof(Delete))]
        public ActionResult Delete(string Transcation)
        {

            var query = context.V5McAppOrderSplitBookingsAdjustments.Where(x => x.Transcation == Transcation).ToList();
            context.V5McAppOrderSplitBookingsAdjustments.RemoveRange(query);
            int res = context.SaveChanges();
            return Ok(res);

        }





    }
}
;