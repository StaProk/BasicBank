using BBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BBAPI.Data
{
    public class DataContextEF : DbContext
    {
        private readonly IConfiguration _config;

        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }

        public virtual DbSet<User> Users {get; set;}
        public virtual DbSet<Account> Account {get; set;}
        public virtual DbSet<Loan> Loan {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                        optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BBAppSchema");

            modelBuilder.Entity<User>()
                .ToTable("Users", "BBAppSchema")
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Account>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Loan>()
                .HasKey(u => u.UserId);
        }

    }

}
