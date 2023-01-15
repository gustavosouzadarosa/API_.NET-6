using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Column(Order = 1)]
        public int Codigo { get; set; }
        [Column(Order = 2)]
        [MaxLength(255)]
        public string Descricao { get; set; }
        [Column(Order = 3)]
        public bool Situacao { get; set; }
    }
}
