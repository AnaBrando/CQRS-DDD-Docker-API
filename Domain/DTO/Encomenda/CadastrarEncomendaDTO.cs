using System.ComponentModel.DataAnnotations;
using Domain.DTO.Pedido;

namespace Domain.DTO.Encomenda
{
    public class CadastrarEncomendaDTO
    {
        [Required(ErrorMessage="uma encomenda deve ter pelo menos um pedido")]
        public CadastroPedidoDTO Pedido {get;set;}
    }
}