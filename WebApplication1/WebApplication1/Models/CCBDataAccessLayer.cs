
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplicationss1.Models
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
    }
}
