using AutoMapper;
using Core.Handlers;
using Core.Intefaces;
using Core.Interfaces;
using Core.Notification;
using Domain.AutoMapper;
using Domain.Entidades.Commands;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Infra.Context;
using Infra.EventSourcing;
using Infra.Repository;
using Infra.Uow;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.EncomendaService;
using Service.EquipeService;
using Service.PedidoService;
using Service.Produto;
using Service.UsuarioService;

namespace CrossCutting.Injector
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IEventStoragedRepository,EventStoreRepository>();
            
            #region  Commands
            services.AddScoped<IRequestHandler<RegistrarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<EditarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirPedidoCommand, bool>, PedidoCommandHandler>();

            services.AddScoped<IRequestHandler<RegistrarProdutoCommand, bool>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<EditarProdutoCommand, bool>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirProdutoCommand, bool>, ProdutoCommandHandler>();
            
            services.AddScoped<IRequestHandler<RegistrarEncomendaCommand, bool>, EncomendaCommandHandler>();
            services.AddScoped<IRequestHandler<EditarEncomendaCommand, bool>, EncomendaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirEncomendaCommand, bool>, EncomendaCommandHandler>();
            
            services.AddScoped<IRequestHandler<RegistrarEquipeCommand, bool>, EquipeCommandHandler>();
            services.AddScoped<IRequestHandler<EditarEquipeCommand, bool>, EquipeCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirEquipeCommand, bool>, EquipeCommandHandler>();
            
            #endregion

            #region Infra
            services.AddScoped<BancoContext>();
            services.AddScoped<IPedidoRepository,PedidoRepository>();
            services.AddScoped<IProdutoRepository,ProdutoRepository>();
            services.AddScoped<IEncomendaRepository,EncomendaRepository>();
            services.AddScoped<IEquipeRepository,EquipeRepository>();

            services.AddDbContext<ApplicationDbContext>(builder =>
            {
                builder.UseSqlServer(config.GetConnectionString("Conexao"));
            });
             services.AddDbContext<BancoContext>(builder =>
            {
                builder.UseSqlServer(config.GetConnectionString("Conexao"));
            });
            #endregion

            #region Data.EventSourcing
                services.AddScoped<IEventStoragedRepository, EventStoreRepository>();
                services.AddScoped<IEventStore,EventStore>();
                services.AddScoped<EventContext>();
            #endregion
                services.AddScoped<IUserService,UserService>();
                services.AddScoped<IPedidoService,PedidoService>();
                services.AddScoped<IProdutoService,ProdutoService>();
                services.AddScoped<IEncomendaService,EncomendaService>();
                services.AddScoped<IEquipeService,EquipeService>();
                IMapper mapper = AutoMapperConfiguration.RegisterMappings().CreateMapper();
                services.AddSingleton(mapper);

        }
    }
}