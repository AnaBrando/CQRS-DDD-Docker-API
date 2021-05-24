using System.Threading;
using System.Threading.Tasks;
using Core.Intefaces;
using Core.Interfaces;
using Core.Notification;
using Domain.Core;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using MediatR;

namespace Domain.Entidades.Commands
{
    public class ProdutoCommandHandler : CommandHandler,
            IRequestHandler<RegistrarProdutoCommand, bool>,
            IRequestHandler<EditarProdutoCommand, bool>,
            IRequestHandler<ExcluirProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoCommandHandler(
                IUnitOfWork uow, 
                IProdutoRepository produtoRepository,
                IMediatorHandler mediator, 
                INotificationHandler<DomainNotification> notifications) 
            : base(uow, mediator, notifications)
        {
            _produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(EditarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.ObterPorId(request.Id);
            produto.Descricao = request.Descricao;
            produto.Valor = request.Valor;
           _produtoRepository.Atualizar(produto);
            if (Commit()) { }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RegistrarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto();
            produto.Descricao = request.Descricao;
            produto.Valor = request.Valor;
           _produtoRepository.Adicionar(produto);
            if (Commit()) { }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.ObterPorId(request.Id);
           _produtoRepository.Excluir(produto);
            if (Commit()) { }

            return Task.FromResult(true);
        }
    }
}
