using Microsoft.EntityFrameworkCore;
using PostOfficeBackend.Entities;

namespace PostOfficeBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}

