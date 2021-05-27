using Microsoft.EntityFrameworkCore;
using NewCardNumber.Models;

namespace NewCardNumber.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Card> cards { get; set; }
    }
}