#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Models;

public class MvcSchoolContext : DbContext
{
    public MvcSchoolContext(DbContextOptions<MvcSchoolContext> options)
        : base(options)
    {
    }

    public DbSet<School.Models.Country> Countries { get; set; }

    public DbSet<School.Models.Class> Classes { get; set; }

    public DbSet<School.Models.Student> Students { get; set; }





    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).modified_date = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).created_date = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }
}
