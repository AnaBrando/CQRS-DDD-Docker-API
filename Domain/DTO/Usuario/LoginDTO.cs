using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Usuario
{
    public class LoginDTO
    {
         [Required(ErrorMessage="O campo email é obrigatório")]
        [EmailAddress(ErrorMessage="o campo {0} está em formato inválido")]
        public string Email{get;set;}
        [Required(ErrorMessage="O campo senha é obrigatório")]
        public string Password{get;set;}
    }
}