using CartSystem.Models.Domain;

namespace CartSystem.Repository
{
    public interface ICartRepo
    {
        Task<IEnumerable<CartItem>> GetAllAsync();
        Task<CartItem?> GetAsync(int id);
        Task<CartItem?> AddAsync(CartItem cartItem);
        Task<CartItem?> UpdateAsync(CartItem cartItem);
        Task<CartItem?> DeletAsync(int id);




    }
}
