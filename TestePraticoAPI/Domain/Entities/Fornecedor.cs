using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Fornecedor : BaseEntity
    {
        [MaxLength(14)]
        [Column(Order = 4)]
        public string? CNPJ { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}
