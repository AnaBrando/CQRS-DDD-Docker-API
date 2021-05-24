using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Usuario
{
    public class UsuarioDTO
    {   
        [Required(ErrorMessage="O campo email é obrigatório")]
        [EmailAddress(ErrorMessage="o campo {0} está em formato inválido")]
        public string Email{get;set;}
        [Required(ErrorMessage="O campo senha é obrigatório")]
        [StringLength(20,ErrorMessage="o campo {0} precisa estar entre {2} e {1} caracteres",MinimumLength=8)]
        public string Password{get;set;}
        [Compare("Password",ErrorMessage="As senhas não conferem")]
        public string ConfirmPassord{get;set;}
    }
}