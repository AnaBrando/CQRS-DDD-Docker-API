using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Produto
{
    public class AdicionaProdutoDTO
    {
        [Required(ErrorMessage="O campo descrição do produto é obrigatório")]
        
        public string Descricao { get; set; }
        [Required(ErrorMessage="O campo valor do produto é obrigatório")]
        public float Valor { get; set; }

    
    }
}