using Pizzaria.Enums;
using Pizzaria.Helper;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o tipo da conta do usuário")]
        public AdminEnum AdminEnum { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo celular é obrigatório")]
        [Phone(ErrorMessage ="Celular inválido")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "A senha deve ter entre 4 e 8 caracteres.")]
        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }
        public DateTime? EditDate { get; set; }

        public bool PasswordSearch(string password)
        {
            return Password == password;
        }

        public void SetPasswordHash()
        {
            Password = Password.GenerateHash();
        }


    }
}
