using Microsoft.EntityFrameworkCore;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;

namespace oil_exchange_backend.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<CustomerManagement> Customermanagement { get; set; }
        public DbSet<StoreManagement> Store { get; set; }
    }
}
