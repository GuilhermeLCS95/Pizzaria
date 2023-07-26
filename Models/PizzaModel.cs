using Pizzaria.Enums;
namespace Pizzaria.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        public PizzaSizeEnum SizeEnum { get; set; }
        public PizzaFlavorsEnum FlavorsEnum { get; set; }
        public double Price { get; set; }

    }
}
