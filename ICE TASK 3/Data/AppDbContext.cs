using Microsoft.EntityFrameworkCore;

namespace ICE_TASK_3.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Investor> Investors { get; set; }
        public DbSet<InvestmentPortfolio> InvestmentPortfolios { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Cow> Cows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the 1-to-many relationship between InvestmentPortfolio and Investor:
            modelBuilder.Entity<InvestmentPortfolio>()
                .HasOne(ip => ip.Investor)
                .WithMany(i => i.InvestmentPortfolios)
                .HasForeignKey(ip => ip.InvestorID);

            // Configure the 1-to-many relationship between InvestmentPortfolio and Cow:
            modelBuilder.Entity<InvestmentPortfolio>()
                .HasOne(ip => ip.Cow)
                .WithMany(c => c.InvestmentPortfolios)
                .HasForeignKey(ip => ip.CowTag);

            // Configure the 1-to-many relationship between Cow and Farm:
            modelBuilder.Entity<Cow>()
                .HasOne(c => c.Farm)
                .WithMany(f => f.Cows)
                .HasForeignKey(c => c.FarmID);

            // Configure the 1-to-many relationship between Farm and Cow:
            modelBuilder.Entity<Farm>()
                .HasMany(f => f.Cows)
                .WithOne(c => c.Farm)
                .HasForeignKey(c => c.FarmID);
        }
    }
}