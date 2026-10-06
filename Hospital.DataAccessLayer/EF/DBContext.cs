using Hospital.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccessLayer.EF
{
    public class DBContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    DatabaseSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctors");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.FullName)
                    .IsRequired();

                entity.Property(x => x.Specialization)
                    .IsRequired();

                entity.Property(x => x.Experience)
                    .IsRequired();

                entity.Property(x => x.Phone)
                    .IsRequired();

                entity.Property(x => x.Office)
                    .IsRequired();
            });
        }
    }
}