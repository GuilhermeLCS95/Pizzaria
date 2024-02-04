using Pizzaria.Data;
using Pizzaria.Enums;
using Pizzaria.Models;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Repository
{
    public class PurchaseListRepository : IPurchaseListRepository
    {
        private readonly BancoContext _bancoContext;
        public PurchaseListRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public PurchaseListModel GetId(int id)
        {
            return _bancoContext.Purchases.FirstOrDefault(x => x.Id == id);    
        }
        public List<PurchaseListModel> GetAll()
        {
            return _bancoContext.Purchases.ToList();
        }
        public PurchaseListModel Add(PurchaseListModel purchases)
        {
            _bancoContext.Purchases.Add(purchases);
            _bancoContext.SaveChanges();
            return purchases;

        }

        public PurchaseListModel Update(PurchaseListModel purchase)
        {
            PurchaseListModel purchaseDB = GetId(purchase.Id);
            if (purchaseDB == null)
            {
                throw new Exception("Erro ao atualizar informações da pizza.");
            }
            else
            {
                purchaseDB.QntPizza = purchase.QntPizza;
                purchaseDB.Obs = purchase.Obs;
                purchaseDB.UpdatePrice();


                _bancoContext.Purchases.Update(purchaseDB);
                _bancoContext.SaveChanges();

                return purchaseDB;
            }
        }

        public bool Delete(int id)
        {
            PurchaseListModel purchaseDB = GetId(id);
            if (purchaseDB == null)
            {
                throw new Exception("Erro ao excluir essa pizza.");
            }
            else
            {
                _bancoContext.Purchases.Remove(purchaseDB);
                _bancoContext.SaveChanges();

                return true;
            }
        }
    }
}
