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


        [HttpGet(nameof(GetLabel))]
        public ActionResult GetLabel()
        {
            MissionControlContext context = new MissionControlContext();
            return Ok(context.V5McAppStandardSplitLabels);
        }


        [HttpGet(nameof(GetCCb))]
        public ActionResult GetCCb()
        {
            MissionControlContext context = new MissionControlContext();
            var res = context.V6DwhBookingsOracleNVias.Where(c => !context.V5McAppOrderSplitBookingsAdjustments.Select(b => b.OrderNumber).Contains(c.OrderNumber));
            return Ok(res);
        }

        [HttpGet(nameof(Getl5))]
        public ActionResult Getl5(string Level3Desc, string Level4Desc)
        {
            MissionControlContext context = new MissionControlContext();
            var res = context.DwhProductHierarchies.Where(l3 => l3.Level3Desc == Level3Desc).Where(l4 => l4.Level4Desc == Level4Desc).Select(l5 => l5.Level5Desc).ToList().Distinct();
            return Ok(res);
        }


        [HttpGet(nameof(GetById))]
        public ActionResult<V6DwhBookingsOracleNVia> GetById(string OrderNumber)
        {
            MissionControlContext context = new MissionControlContext();
            return Ok(context.V6DwhBookingsOracleNVias.Where(order => order.OrderNumber == OrderNumber).ToList());
        }


        [HttpPost]
        public ActionResult Insert(List<V5McAppOrderSplitBookingsAdjustment> v6Dwhs)
        {
            using (MissionControlContext context = new MissionControlContext())
            {

                if (v6Dwhs == null)
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
            if (res > 0)
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
                         on sba.Transcation equals sbaa.Transcation
                         where sbaa.SplitType == "Custom Split"
                         select sbaa).Distinct().ToList();

            return Ok(query);
        }


        [HttpGet(nameof(GetStandardData))]
        public ActionResult GetStandardData(string OrderNumber)
        {
            var query = from sba in context.V6DwhBookingsOracleNVias
                        join sbaa in context.SbodwV5SalesLeaderHierarchyVs
                        on sba.District equals sbaa.District
                        where sba.OrderNumber == OrderNumber
                        group sba by new { sba.TransDate, sba.TransDatePeriodName, sba.OrderNumber, sba.PoNumber, sba.District, sba.L3BusinessGroup, sba.L4BusinessUnit, sba.L5ProductLine, sbaa.Region, sbaa.SubRegion } into g
                        select new
                        {
                            OrderNumber = g.Key.OrderNumber,
                            PoNumber = g.Key.PoNumber,
                            District = g.Key.District,
                            L3BusinessGroup = g.Key.L3BusinessGroup,
                            L4BusinessUnit = g.Key.L4BusinessUnit,
                            L5ProductLine = g.Key.L5ProductLine,
                            TransDate = g.Key.TransDate,
                            TransDatePeriodName = g.Key.TransDatePeriodName,
                            CcAmtGrossBookings = g.Sum(x => x.CcAmtGrossBookings),
                            Region = g.Key.Region,
                            SubRegion = g.Key.SubRegion,
                        };


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



        [HttpPost(nameof(StandarSplit))]
        public ActionResult StandarSplit(StandardSplit standardSplit)
        {
            V5McAppStandardSplitLabel standardSplitLabel = new V5McAppStandardSplitLabel();
            BookingAdjustments booking = new BookingAdjustments();
            standardSplitLabel = objemployee.GetlabelById(Convert.ToInt32(standardSplit.SelectedLabel));
            List<V5McAppOrderSplitBookingsAdjustment> v5McAppOrderSplits = objemployee.GetOrderById(standardSplit.OrderNumber);
            int res = 0;

            if (v5McAppOrderSplits.Count > 0)
            {
                foreach (V5McAppOrderSplitBookingsAdjustment item in v5McAppOrderSplits)
                {
                    Guid guid = Guid.NewGuid();
                    item.EntryBy = System.Environment.MachineName;
                    item.EntryDate = DateTime.Now;
                    item.SplitType = "Standard Split";
                    item.Transcation = guid.ToString();
                    V5McAppOrderSplitBookingsAdjustment bs = new V5McAppOrderSplitBookingsAdjustment();
                    bs.OrderNumber = item.OrderNumber;
                    booking.booking.OrderNumber = item.OrderNumber;
                    bs.FiscalPeriod = item.FiscalPeriod;
                    booking.booking.FiscalPeriod = item.FiscalPeriod;
                    bs.L3BusinessGroup = item.L3BusinessGroup;
                    booking.booking.L3BusinessGroup = item.L3BusinessGroup;
                    bs.L4BusinessUnit = item.L4BusinessUnit;
                    booking.booking.L4BusinessUnit = item.L4BusinessUnit;
                    bs.L5ProductLine = item.L5ProductLine;
                    booking.booking.L5ProductLine = item.L5ProductLine;
                    bs.TransDate = item.TransDate;
                    booking.booking.TransDate = item.TransDate;
                    bs.Region = item.Region;
                    booking.booking.Region = item.Region;
                    bs.District = item.District;
                    booking.booking.District = item.District;
                    bs.SubRegion = item.SubRegion;
                    booking.booking.SubRegion = item.SubRegion;
                    bs.Transcation = item.Transcation;
                    booking.booking.Transcation = item.Transcation;
                    bs.EntryBy = item.EntryBy;
                    booking.booking.EntryBy = item.EntryBy;
                    bs.EntryDate = item.EntryDate;
                    booking.booking.EntryBy = item.EntryBy;
                    bs.SplitType = "Standard Split";
                    booking.booking.SplitType = "Standard Split";
                    bs.Comments = standardSplit.Comments;
                    booking.booking.Comments = standardSplit.Comments;
                    bs.CcAmtGrossBookings = item.CcAmtGrossBookings;
                    booking.booking.CcAmtGrossBookings = item.CcAmtGrossBookings;
                    bs.Transcation = item.Transcation;
                    booking.booking.Transcation = item.Transcation;
                    bs.SplitPercent = "-100";
                    booking.booking.SplitPercent = "100";
                    if (item.Bookings > 0)
                    {
                        bs.Bookings = -1 * item.CcAmtGrossBookings;
                    }
                    else
                    {
                        bs.Bookings = item.CcAmtGrossBookings;
                    }
                    booking.booking.Bookings = item.CcAmtGrossBookings;
                    res = objemployee.InsertCCb(bs);

                    if (standardSplitLabel.District1 != null)
                    {
                        bs.Id = 0;
                        //booking.booking.Id = 0;
                        bs.District = standardSplitLabel.District1;
                        booking.booking.District = standardSplitLabel.District1;
                        bs.SplitPercent = standardSplitLabel.SplitPer1.ToString();
                        booking.booking.SplitPercent = standardSplitLabel.SplitPer1.ToString();
                        bs.Bookings = item.CcAmtGrossBookings;
                        booking.booking.Bookings = item.CcAmtGrossBookings;
                        res = objemployee.InsertCCb(bs);
                    }


                    if (standardSplitLabel.District2 != null)
                    {
                        bs.Id = 0;
                        //booking.booking.Id = 0;
                        bs.District = standardSplitLabel.District2;
                        booking.booking.District = standardSplitLabel.District2;
                        bs.SplitPercent = standardSplitLabel.SplitPer2.ToString();
                        booking.booking.SplitPercent = standardSplitLabel.SplitPer2.ToString();
                        bs.Bookings = item.CcAmtGrossBookings;
                        booking.booking.Bookings = item.CcAmtGrossBookings;
                        res = objemployee.InsertCCb(bs);
                    }
                }
            }
            return Ok(res);
        }
    }
 
}
