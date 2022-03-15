
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


    }
}
