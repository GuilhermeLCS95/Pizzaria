using Pizzaria.Models;

namespace Pizzaria.Repository
{
    public interface ICartRepository
    {
        CartModel GetId(int id);
        List<CartModel> GetAll();
        CartModel Add(CartModel cart);
        bool Delete(int id);
    }
}
