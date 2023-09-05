using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo login é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Password { get; set; }
    }
}
