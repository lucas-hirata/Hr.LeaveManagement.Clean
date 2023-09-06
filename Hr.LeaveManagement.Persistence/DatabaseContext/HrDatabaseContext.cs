using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Domain.Common;

using Microsoft.EntityFrameworkCore;

namespace Hr.LeaveManagement.Persistence.DatabaseContext;

public class HrDatabaseContext : DbContext
{
	public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : base(options)
	{

	}

    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.ModifiedAt = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
