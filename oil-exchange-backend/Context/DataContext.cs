using Microsoft.EntityFrameworkCore;
using oil_exchange_backend.Models;

namespace oil_exchange_backend.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<users> users { get; set; }
        public DbSet<CustomerManagement> customermanagement { get; set; }
    }
}
