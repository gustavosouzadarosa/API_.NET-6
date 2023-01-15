using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Response;
using Domain.Validators;
using Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        protected readonly DataBaseContext _dbContext;

        public ProdutoController(IProdutoService produtoService, IMapper mapper, DataBaseContext dbContext)
        {
            _produtoService = produtoService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "~/Buscar")]
        public ActionResult<ProdutoResponse> Buscar(int? codigo, string? descricao, bool? situacao, 
                                                    DateTime? dataFabricacao, DateTime? dataValidade, int? fornecedorCodigo,
                                                    int resultadosPorPagina = 2, int pagina = 0)
        {
            try
            {
                var totalDeProdutos = _dbContext.Produtos.Count();
                var quantidadeDePaginas = Math.Ceiling(totalDeProdutos / (float)resultadosPorPagina);

                if (pagina > quantidadeDePaginas)
                    throw new Exception($"Página {pagina.ToString()} não existe." +
                                        $" O total de páginas atual é {quantidadeDePaginas.ToString()}" +
                                        $" exibindo {resultadosPorPagina.ToString()} resultados por página.");

                ProdutoDTO filtros = new()
                {
                    Codigo = codigo,
                    Descricao = descricao,
                    Situacao = situacao,
                    DtFabricacao = dataFabricacao,
                    DtValidade = dataValidade,
                    FornecedorCodigo = fornecedorCodigo
                };

                var produtos = _produtoService.BuscarProdutos(filtros, pagina,
                                                              (int)resultadosPorPagina,
                                                              (int)quantidadeDePaginas);
                var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);

                return Ok(new ProdutoResponse()
                {
                    Produtos = produtosDTO,
                    TotalDeProdutos = totalDeProdutos,
                    ResultadosPorPagina = (int)resultadosPorPagina,
                    QuantidadeDePaginas = (int)quantidadeDePaginas,
                    Pagina = pagina
                }); ;
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar produto(s). " + ex.Message);
            }
        }

        [HttpPost(Name = "~/Adicionar")]
        public ActionResult Adicionar([FromBody] ProdutoDTO produto)
        {
            try
            {
                var objeto = _mapper.Map<Produto>(produto);
                _produtoService.Add<ProdutoValidators>(objeto);
                return Ok("Produto adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao adicionar um novo produto. " + ex.Message);
            }
        }

        [HttpPost(Name = "~/Atualizar")]
        public ActionResult Atualizar(int codigo, string? descricao, bool? situacao,
                                      int? fornecedorCodigo)
        {
            try
            {
                var objeto = _produtoService.GetById(codigo);

                if (objeto == null)
                    throw new Exception($"Produto de código '{codigo}' não encontrado!");

                if (descricao != null)
                    objeto.Descricao = descricao;

                if (situacao != null)
                    objeto.Situacao = (bool)situacao;

                if (fornecedorCodigo != null)
                    objeto.FornecedorCodigo = (int)fornecedorCodigo;

                _produtoService.Update<ProdutoValidators>(objeto);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar o produto. " + ex.Message);
            }
        }

        [HttpPost(Name = "~/Deletar")]
        public ActionResult Deletar(int codigo)
        {
            try
            {
                _produtoService.Delete(codigo);
                return Ok("Produto deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar o produto. " + ex.Message);
            }
        }
    }
}