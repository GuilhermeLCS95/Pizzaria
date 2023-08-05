using Pizzaria.Data;
using Pizzaria.Enums;
using Pizzaria.Migrations;
using Pizzaria.Models;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BancoContext _bancoContext;
        public UserRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UserModel GetId(int id)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Id == id);    
        }
        public List<UserModel> GetAll()
        {
            return _bancoContext.Users.ToList();
        }
        public UserModel Add(UserModel user)
        {
            _bancoContext.Users.Add(user);
            _bancoContext.SaveChanges();
            return user;

        }

        public UserModel Update(UserModel user)
        {
            UserModel userDB = GetId(user.Id);
            if (userDB == null)
            {
                throw new Exception("Erro ao atualizar informações da pizza.");
            }
            else
            {
                userDB.Name = user.Name;
                userDB.Email = user.Email;
          

                _bancoContext.Users.Update(userDB);
                _bancoContext.SaveChanges();

                return userDB;
            }
        }

        public bool Delete(int id)
        {
            UserModel userDB = GetId(id);
            if (userDB == null)
            {
                throw new Exception("Erro ao excluir essa pizza.");
            }
            else
            {
                _bancoContext.Users.Remove(userDB);
                _bancoContext.SaveChanges();

                return true;
            }
        }
    }
}
