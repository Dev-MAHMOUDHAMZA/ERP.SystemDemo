
using ERP.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ERP.Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<Employee>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.HasSequence<int>("UserID").StartsAt(1).IncrementsBy(1);
        //builder.Entity<ApplicationEmployee>().Property(t => t.UserID).HasDefaultValueSql("NEXT VALUE FOR UserID");

        #region MyRegion
        //builder.Entity<EmployeeLog>()
        //  .HasOne(e => e.CreatedBy)
        //  .WithMany(e => e.EmployeeLogs)
        //  .HasForeignKey(e => e.CreatedById)
        //  .OnDelete(DeleteBehavior.Restrict);

        //builder.Entity<EmployeeLog>()
        //    .HasOne(e => e.Employee)
        //    .WithMany(e => e.CreatedLogs)
        //    .HasForeignKey(e => e.EmployeeId)
        //    .OnDelete(DeleteBehavior.Restrict); 
        #endregion


        //Register Configuration 
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    //public virtual DbSet<AttachmentType> AttachmentType { get; set; }

}
