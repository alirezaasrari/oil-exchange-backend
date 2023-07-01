using Microsoft.EntityFrameworkCore;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;

namespace oil_exchange_backend.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<CustomerManagement> customermanagement { get; set; }
    }
}
