using Microsoft.EntityFrameworkCore;
using Mini_shop.Models;

namespace Mini_shop.DataAccessLayer
{
   
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Card> Card { get; set; }
        
    }
    }

