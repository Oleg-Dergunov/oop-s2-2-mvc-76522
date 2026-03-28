using InspectionTracker.Domain;
using InspectionTracker.MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InspectionTracker.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Premises> Premises { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // DateOnly converters
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d)
            );

            var nullableDateOnlyConverter = new ValueConverter<DateOnly?, DateTime?>(
                d => d.HasValue ? d.Value.ToDateTime(TimeOnly.MinValue) : null,
                d => d.HasValue ? DateOnly.FromDateTime(d.Value) : null
            );

            // Apply converters automatically to all DateOnly properties
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateOnly))
                        property.SetValueConverter(dateOnlyConverter);

                    if (property.ClrType == typeof(DateOnly?))
                        property.SetValueConverter(nullableDateOnlyConverter);
                }
            }

            // Seed data
            DataSeeder.Seed(builder);

            // Premises → Inspections (1-many)
            builder.Entity<Premises>()
                .HasMany(p => p.Inspections)
                .WithOne(i => i.Premises)
                .HasForeignKey(i => i.PremisesId)
                .OnDelete(DeleteBehavior.Cascade);

            // Inspection → FollowUps (1-many)
            builder.Entity<Inspection>()
                .HasMany(i => i.FollowUps)
                .WithOne(f => f.Inspection)
                .HasForeignKey(f => f.InspectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Premises>()
                .Property(p => p.RiskRating)
                .IsRequired();

            builder.Entity<Inspection>()
                .Property(i => i.Outcome)
                .IsRequired();
        }
    }
}
