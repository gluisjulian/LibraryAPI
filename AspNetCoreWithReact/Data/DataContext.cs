using AspNetCoreWithReact.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWithReact.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Library> Libraries { get; set; }
    }
}
