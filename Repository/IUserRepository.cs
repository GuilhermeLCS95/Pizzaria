using Pizzaria.Models;

namespace Pizzaria.Repository
{
    public interface IUserRepository
    {
        UserModel SearchForLogin (string login);
        UserModel GetId(int id);
        List<UserModel> GetAll();
        UserModel Add(UserModel user);
        UserModel Update(UserModel user);
        bool Delete(int id);
    }
}
