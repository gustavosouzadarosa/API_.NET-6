using Domain.DTO;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProdutoService : IBaseService<Produto>
    {
        IList<Produto> BuscarProdutos(ProdutoDTO filtros, int pagina, int resultadosPorPagina,
                                      int quantidadeDePaginas);
    }
}
