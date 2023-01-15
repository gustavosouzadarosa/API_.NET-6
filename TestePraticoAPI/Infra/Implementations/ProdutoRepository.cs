using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Infra.Implementations
{
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly DataBaseContext _dbContext;

        public ProdutoRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Produto> BuscarProdutos(ProdutoDTO filtros, int pagina, int resultadosPorPagina, int quantidadeDePaginas)
        {
            try
            {
                var predicate = PredicateBuilder.New<Produto>(true);

                if (filtros != null)
                {
                    if (filtros.Codigo != null)
                        predicate.And(x => x.Codigo == filtros.Codigo);

                    if (filtros.Descricao != null)
                        predicate.And(x => x.Descricao == filtros.Descricao);

                    if (filtros.Situacao != null)
                        predicate.And(x => x.Situacao == filtros.Situacao);

                    if (filtros.DtFabricacao != null)
                        predicate.And(x => x.DataFabricacao == filtros.DtFabricacao);

                    if (filtros.DtValidade != null)
                        predicate.And(x => x.DataValidade == filtros.DtValidade);

                    if (filtros.FornecedorCodigo != null)
                        predicate.And(x => x.FornecedorCodigo == filtros.FornecedorCodigo);
                }

                if (pagina > 0 && resultadosPorPagina > 0)
                {
                    return _dbContext.Produtos.Skip((pagina - 1) * resultadosPorPagina)
                           .Take(resultadosPorPagina).AsNoTracking().Where(predicate)
                           .ToList();
                }
                else
                {
                    return _dbContext.Produtos.AsNoTracking().Where(predicate).ToList();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insert(Produto obj)
        {
            try
            {
                _dbContext.Set<Produto>().Add(obj);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Produto obj)
        {
            try
            {
                _dbContext.Set<Produto>().Update(obj);
                _dbContext.SaveChanges();
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
                var obj = GetById(codigo);
                if (obj == null || !obj.Situacao)
                    throw new Exception($"Produto de código '{codigo}' não encontrado!");            
                obj.Situacao = false;
                Update(obj);         
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
                return _dbContext.Set<Produto>().Where(x => x.Codigo == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
