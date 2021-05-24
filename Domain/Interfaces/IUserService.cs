using System.Threading.Tasks;
using Domain.DTO;
using Domain.DTO.Usuario;


namespace Domain.Interfaces
{
    public interface IUserService
    {
         Task<ReponseDTO<UsuarioDTO>> RegistrarUsuario(UsuarioDTO dto);

         Task<ReponseDTO<UsuarioDTO>> LogarUsuario(LoginDTO dto);

    }
}