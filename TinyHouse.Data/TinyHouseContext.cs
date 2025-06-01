using Microsoft.EntityFrameworkCore;

namespace TinyHouse.Data
{
    public class TinyHouseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı dosyası oluşturulacak
            optionsBuilder.UseSqlite("Data Source=tinyhouse.db");
        }
    }
}
