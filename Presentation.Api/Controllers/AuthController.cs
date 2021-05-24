using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.ApplicationUser;
using Core.Interfaces;
using Core.Notification;
using Domain.DTO.Usuario;
using Domain.Intefaces;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Presentation.Api.Extensions;

namespace Presentation.Api.Controllers
{
    [Route("api")]
    public class AuthController : BaseController
    {   
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        public AuthController(
                    INotificationHandler<DomainNotification> notifications, 
                    IUserService userService,
                    IMediatorHandler mediator,
                    IOptions<AppSettings> appSettings,
                    SignInManager<ApplicationUser> signInManager,
                    UserManager<ApplicationUser> userManager
                    ) : base(notifications, /*user*/ mediator)
        {
                _signInManager = signInManager; 
                _userManager = userManager;
                _userService = userService;
                _appSettings = appSettings.Value;
        }
        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registrar(UsuarioDTO model){
                if(!ModelStateValida()){
                    return Response();
                }
                
                var user =  new ApplicationUser{
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result =  await _userManager.CreateAsync(user,model.Password);

                if(result.Succeeded){
                    await _signInManager.SignInAsync(user,false);
                    return Response(GerarJwt());
                }
                foreach(var error in result.Errors){
                    NotificarErro("403",error.Description);
                }

                return Response(model);
  
        }
        
        [HttpPost("entrar")]
        public async Task<IActionResult> Login (LoginDTO dto){
            if(!ModelStateValida()){
                    return Response();
            }
            var result = await _signInManager.PasswordSignInAsync(dto.Email,dto.Password,false,true);
            if(result.Succeeded){
                return Response(GerarJwt());
            }
            if(result.IsLockedOut){
                NotificarErro("403","Usuário temporariamente bloqueado por tentativas inválidas");
                return Response(dto);
            }
            NotificarErro("403","Usuário ou senha inválidos");
            return Response(dto);
        }

        private string GerarJwt(){
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            try
            {
                var token = tokenHandler.CreateToken(new SecurityTokenDescriptor{
                    Issuer  = _appSettings.Emissor,
                    Audience = _appSettings.ValidoEm,
                    Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
                });
                var enconded = tokenHandler.WriteToken(token);
                return enconded;
            }
            catch (System.Exception ex)
            {
                var item = ex.Message;
                throw;
            }
            

    
        }
    }
}