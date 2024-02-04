namespace Pizzaria.Models
{
    public class PurchaseListModel
    {
        public int Id { get; set; }          
        public int QntPizza { get; set; }
        public string Obs {  get; set; }
        public decimal TotalPrice { get; set; }

        public int IdPizza { get; set; }
        public PizzaModel Pizza { get; set; }

        public int IdCart { get; set; }
        public CartModel Cart { get; set; }


        public void UpdatePrice()
        {
            TotalPrice = Pizza.Price * QntPizza;
            
        }
    }
}
