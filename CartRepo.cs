using CartSystem.Data;
using CartSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CartSystem.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly CartDbContext _cartDbContext;

        public CartRepo(CartDbContext cartDbContext)
        {
            this._cartDbContext = cartDbContext;
        }
        public async Task<CartItem?> AddAsync(CartItem cartItem)
        {
            await _cartDbContext.CartItems.AddAsync(cartItem);
            await _cartDbContext.SaveChangesAsync();
            return cartItem;
        }

        public async Task<CartItem?> DeletAsync(int id)
        {
            var existingCartItem = await _cartDbContext.CartItems.FindAsync(id);
            if (existingCartItem != null)
            {
                _cartDbContext.CartItems.Remove(existingCartItem);
                await _cartDbContext.SaveChangesAsync();
                return existingCartItem;
            }
            return null;
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await _cartDbContext.CartItems.ToListAsync();

        }

        public async Task<CartItem?> GetAsync(int id)
        {
            return await _cartDbContext.CartItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CartItem?> UpdateAsync(CartItem cartItem)
        {
            var existingCartItem = await _cartDbContext.CartItems.FindAsync(cartItem.Id);
            if( existingCartItem != null)
            {
                existingCartItem.Id = cartItem.Id;
                existingCartItem.Colour = cartItem.Colour;
                existingCartItem.Quantity = cartItem.Quantity;
                await _cartDbContext.SaveChangesAsync();
                return existingCartItem;
            }
            return null;

        }
    }
}
