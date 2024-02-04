using Pizzaria.Data;
using Pizzaria.Enums;
using Pizzaria.Models;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly BancoContext _bancoContext;
        public CartRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public CartModel GetId(int id)
        {
            return _bancoContext.Carts.FirstOrDefault(x => x.Id == id);    
        }
        public List<CartModel> GetAll()
        {
            return _bancoContext.Carts.ToList();
        }
        public CartModel Add(CartModel cart)
        {
            _bancoContext.Carts.Add(cart);
            _bancoContext.SaveChanges();
            return cart;

        }

        public bool Delete(int id)
        {
            CartModel cartDB = GetId(id);
            if (cartDB == null)
            {
                throw new Exception("Erro ao excluir essa pizza.");
            }
            else
            {
                _bancoContext.Carts.Remove(cartDB);
                _bancoContext.SaveChanges();

                return true;
            }
        }
    }
}
