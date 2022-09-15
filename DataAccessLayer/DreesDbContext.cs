using Microsoft.EntityFrameworkCore;

namespace Alloy.DataAccessLayer
{
    public class DreesDbContext : DbContext
    {
        public DreesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AR_AREA> AR_AREA { get; set; }
        public DbSet<DSC_DESIGN_CENTER> DSC_DESIGN_CENTER { get; set; }
    }
}
