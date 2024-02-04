using Pizzaria.Models;

namespace Pizzaria.Repository
{
    public interface IPurchaseListRepository
    {
        PurchaseListModel GetId(int id);
        List<PurchaseListModel> GetAll();
        PurchaseListModel Add(PurchaseListModel purchase);
        PurchaseListModel Update(PurchaseListModel purchase);
        bool Delete(int id);
    }
}
