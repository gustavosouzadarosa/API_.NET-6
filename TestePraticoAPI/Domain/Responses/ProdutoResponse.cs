using Domain.DTO;

namespace Domain.Response
{
    public class ProdutoResponse
    {
        public List<ProdutoDTO> Produtos { get; set; }
        public int? TotalDeProdutos { get; set; }
        public int? ResultadosPorPagina { get; set; }
        public int? QuantidadeDePaginas { get; set; }
        public int Pagina { get; set; }
    }
}
