namespace Pizzaria.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public UserModel User { get; set; }

        public ICollection<PurchaseListModel> Purchases { get; set; }
    }
}
