using Swashbuckle.AspNetCore.Annotations;

namespace Domain.DTO
{
    public class ProdutoDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int? Codigo { get; set; }
        public string? Descricao { get; set; }
        public bool? Situacao { get; set; }
        public DateTime? DtFabricacao { get; set; }
        public DateTime? DtValidade { get; set; }
        public int? FornecedorCodigo { get; set; }
    }
}
