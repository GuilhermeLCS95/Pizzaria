using Pizzaria.Models;

namespace Pizzaria.Helper
{
    public interface IUserSession
    {
        void CreateUserSession(UserModel user);
        void DeleteUserSession();
        UserModel SearchUserSession();
    }
}
