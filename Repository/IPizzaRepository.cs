using Pizzaria.Models;

namespace Pizzaria.Repository
{
    public interface IPizzaRepository
    {
        PizzaModel GetId(int id);
        List<PizzaModel> GetAll();
        PizzaModel Add(PizzaModel pizza);
        PizzaModel Update(PizzaModel pizza);
        bool Delete(int id);
    }
}
