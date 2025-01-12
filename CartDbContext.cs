using Microsoft.EntityFrameworkCore;
using CartSystem.Models.Domain;

namespace CartSystem.Data
{
    public class CartDbContext: DbContext
    {
        public CartDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
