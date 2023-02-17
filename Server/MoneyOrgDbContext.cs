using Microsoft.EntityFrameworkCore;
using MoneyOrg.Client.Shared;

namespace MoneyOrg.Server
{
    public class MoneyOrgDbContext : DbContext
    {
        public MoneyOrgDbContext(DbContextOptions<MoneyOrgDbContext> options)
: base(options) { }
        public DbSet<IncExp>? IncomeExpense { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var incExpEntity = modelBuilder.Entity<IncExp>();
                incExpEntity.HasKey(IncExp => IncExp.Id);

        }

    }
}
