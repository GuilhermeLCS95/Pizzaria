using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Pizzaria.Models;

namespace Pizzaria.Helper
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserSession(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreateUserSession(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("userLogged", value);
        }

        public void DeleteUserSession()
        {
            _httpContext.HttpContext.Session.Remove("userLogged");
        }

        public UserModel SearchUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("userLogged");

            if (string.IsNullOrEmpty(userSession)) return null;
            return JsonConvert.DeserializeObject<UserModel>(userSession);
      
        }
    }
}
