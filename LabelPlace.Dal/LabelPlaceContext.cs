using LabelPlace.DAL.Configurations;
using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabelPlace.Dal
{
    public class LabelPlaceContext : DbContext
    {
        public LabelPlaceContext()
        {
        }

        public LabelPlaceContext(DbContextOptions<LabelPlaceContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TextAnnotation> TextAnnotations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyConfiguration).Assembly);
        }
    }
}
