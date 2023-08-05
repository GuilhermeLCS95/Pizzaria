using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Password { get; set; }

    }
}
