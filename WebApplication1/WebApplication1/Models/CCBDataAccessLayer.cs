
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class CCBDataAccessLayer
    {
        MissionControlContext db = new MissionControlContext();

        public int InsertCCb(V5McAppOrderSplitBookingsAdjustment v5McAppOrderSplit)
        {
            db.V5McAppOrderSplitBookingsAdjustments.Add(v5McAppOrderSplit);
            db.SaveChanges();
            return 1;
        }

        public int InsertCCbAudit(V5McAppOrderSplitBookingsAdjustmentsAudit v5McAppOrderSplitAudit)
        {
            db.V5McAppOrderSplitBookingsAdjustmentsAudits.Add(v5McAppOrderSplitAudit);
            db.SaveChanges();
            return 1;
        }


        public int GetAuditData(string Transcation)
        {
            db.V5McAppOrderSplitBookingsAdjustmentsAudits.Where(order => order.Transcation == Transcation).ToList();
            return 1;
        }

        public V5McAppStandardSplitLabel GetlabelById(int Id)
        {
            V5McAppStandardSplitLabel v5McAppStandardSplitLabel = new V5McAppStandardSplitLabel();
           v5McAppStandardSplitLabel = db.V5McAppStandardSplitLabels.FirstOrDefault(x => x.Id == Id);
           return v5McAppStandardSplitLabel;

        }

        public List<V5McAppOrderSplitBookingsAdjustment> GetOrderById(string OrderNumber)
        {
            var data = new List<V5McAppOrderSplitBookingsAdjustment>();
            var query = (from sba in db.V6DwhBookingsOracleNVias
                        join sbaa in db.SbodwV5SalesLeaderHierarchyVs
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
                            
                        }).ToList();
            if(query.Count >0)
            {
                foreach(var item in query)
                {
                    data.Add(new V5McAppOrderSplitBookingsAdjustment()
                    {
                        OrderNumber = item.OrderNumber,
                        District = item.District,
                        L3BusinessGroup = item.L3BusinessGroup,
                        L4BusinessUnit = item.L4BusinessUnit,
                        L5ProductLine = item.L5ProductLine,
                        TransDate = item.TransDate,
                        FiscalPeriod = item.TransDatePeriodName,
                        CcAmtGrossBookings = item.CcAmtGrossBookings,
                        Region = item.Region,
                        SubRegion = item.SubRegion

                    });
                }
            }
            return data ;

           

        }


       

    }
}
