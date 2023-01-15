using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Validators;
using FluentValidation;

namespace Service.Implementations
{
    public class ProdutoService : IProdutoService
    {
        protected readonly IProdutoRepository _produtoRepository;
        private readonly ProdutoValidators _validator = new ProdutoValidators();

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IList<Produto> BuscarProdutos(ProdutoDTO filtros, int pagina, int resultadosPorPagina, int quantidadeDePaginas)
        {
            try
            {
                return _produtoRepository.BuscarProdutos(filtros, pagina, resultadosPorPagina, quantidadeDePaginas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add<TValidator>(Produto obj) where TValidator : AbstractValidator<Produto>
        {
            try
            {
                _validator.ValidateAndThrow(obj);
                _produtoRepository.Insert(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update<TValidator>(Produto obj) where TValidator : AbstractValidator<Produto>
        {
            try
            {
                _produtoRepository.Update(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int codigo)
        {
            try
            {
                _produtoRepository.Delete(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto GetById(int id)
        {
            try
            {
                return _produtoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
