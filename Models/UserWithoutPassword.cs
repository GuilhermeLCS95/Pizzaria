using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Models
{
    public class UserWithoutPassword
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo celular é obrigatório")]
        [Phone(ErrorMessage = "Celular inválido")]
        public string Phone { get; set; }
    }
}
