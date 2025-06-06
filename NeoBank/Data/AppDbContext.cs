using Microsoft.EntityFrameworkCore;
using NeoBank.Models;

namespace NeoBank.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(x => x.IBAN);
            modelBuilder.Entity<Transaction>()
                .HasKey(x => x.id);
        }
    }
}
