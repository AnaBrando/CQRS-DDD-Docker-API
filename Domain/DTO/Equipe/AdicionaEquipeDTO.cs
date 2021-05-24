using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Equipe
{
    public class AdicionaEquipeDTO
    {
        [Required(ErrorMessage="O campo nome é obrigatório")]
        public string Nome{get;set;}
        [Required(ErrorMessage="O campo descrição é obrigatório")]
        public string Descricao{get;set;}   
        [Required(ErrorMessage="O campo placa é obrigatório")]
        public string Placa{get;set;}
    }
}