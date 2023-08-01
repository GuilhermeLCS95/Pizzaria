using Pizzaria.Data;
using Pizzaria.Enums;
using Pizzaria.Migrations;
using Pizzaria.Models;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly BancoContext _bancoContext;
        public PizzaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public PizzaModel GetId(int id)
        {
            return _bancoContext.Pizzas.FirstOrDefault(x => x.Id == id);    
        }
        public List<PizzaModel> GetAll()
        {
            return _bancoContext.Pizzas.ToList();
        }
        public PizzaModel Add(PizzaModel pizza)
        {
            _bancoContext.Pizzas.Add(pizza);
            _bancoContext.SaveChanges();
            return pizza;

        }

        public PizzaModel Update(PizzaModel pizza)
        {
            PizzaModel pizzaDB = GetId(pizza.Id);
            if (pizzaDB == null)
            {
                throw new Exception("Erro ao atualizar informações da pizza.");
            }
            else
            {
                pizzaDB.PizzaImg = pizza.PizzaImg;
                pizzaDB.PizzaFlavor = pizza.PizzaFlavor;
                pizzaDB.SaltySweetEnum = pizza.SaltySweetEnum;
                pizzaDB.SizeEnum = pizza.SizeEnum;
                pizzaDB.Price = pizza.Price;

                _bancoContext.Pizzas.Update(pizzaDB);
                _bancoContext.SaveChanges();

                return pizzaDB;
            }
        }

        public bool Delete(int id)
        {
            PizzaModel pizzaDB = GetId(id);
            if (pizzaDB == null)
            {
                throw new Exception("Erro ao excluir essa pizza.");
            }
            else
            {
                _bancoContext.Pizzas.Remove(pizzaDB);
                _bancoContext.SaveChanges();

                return true;
            }
        }
    }
}
