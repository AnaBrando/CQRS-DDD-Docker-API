using System.Threading.Tasks;
using Domain.DTO;
using Domain.DTO.Usuario;
using Domain.Interfaces;

namespace Service.UsuarioService
{
    public class UserService : IUserService
    {
      
        public Task<ReponseDTO<UsuarioDTO>> LogarUsuario(LoginDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReponseDTO<UsuarioDTO>> RegistrarUsuario(UsuarioDTO dto)
        {
            throw new System.NotImplementedException();
        }


    }
}