using Microsoft.EntityFrameworkCore;
using CreditTransferSystem.Domain.Models;

namespace CreditTransferSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TransferredCredits> TransferredCredits { get; set; }
    }
}
