using Microsoft.EntityFrameworkCore;
using Monit.Project.DAL.Entities;

namespace Monit.Project.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<DeviceStaticInfo> Devices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
