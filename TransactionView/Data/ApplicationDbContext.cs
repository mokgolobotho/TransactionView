namespace TransactionView.Data;

using Microsoft.EntityFrameworkCore;
using TransactionView.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<AdminTransactionsEntity> admin_transactions { get; set; }
    public DbSet<CecEmployeeEntity> cec_employee { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<CecEmployeeEntity>()
            .Property(b => b.CecEmployeeId)
            .ValueGeneratedNever();
        modelBuilder.Entity<AdminTransactionsEntity>().Property(b => b.id).ValueGeneratedNever();
    }
}
