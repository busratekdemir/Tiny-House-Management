using Microsoft.EntityFrameworkCore;

namespace TinyHouse.Data
{
    public class TinyHouseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TinyHouse> TinyHouses { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\DELL\OneDrive\Desktop\TinyHouseManagement\tinyhouse.db");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FullName = "Admin Kullanıcı",
                Email = "admin@admin.com",
                Password = "admin123",
                Role = "Admin"
            });
        }
    }
}

