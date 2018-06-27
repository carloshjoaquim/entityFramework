using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Produto")]
    public class Produto
    {
        [Key] // Não seria necessário incluir, o EF identifica a propriedade Id e seta como Chave Primária
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(2000)] 
        public string Descricao { get; set; }

        [Range(double.MinValue, 9999999999.999)]
        [Required]
        public decimal Valor { get; set; }

        [ForeignKey("Loja")]
        public int LojaId { get; set; }
        public virtual Loja Loja { get; set; }
    }
}
