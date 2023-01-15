using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        [Column(Order = 4)]
        public DateTime? DataFabricacao { get; set; }
        [Column(Order = 5)]
        public DateTime? DataValidade { get; set; }
        [Column(Order = 6)]
        public int? FornecedorCodigo { get; set; }
        public Fornecedor? Fornecedor { get; set; }
    }
}
