using DomainLayer;
using DomainLayer.CCB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MissionControl.Data
{
    public class UserDbContext :DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> userModels { get; set; }
        public DbSet<oracle_n_vias> oracleModels { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("V5_MC_App_Admin_Users");
            modelBuilder.Entity<oracle_n_vias>().ToTable("V5_MC_App_Order_Split_Bookings_Adjustments");

        }
    }
}
