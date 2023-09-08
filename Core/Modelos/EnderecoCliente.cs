using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Modelos
{
    [Table("ENDERECO_CLIENTE")]
    public class EnderecoCliente
    {
        [Key]
        [Column("CD_ENDERECO_CLIENTE")]
        public int Id { get; set; }
        [Required]
        [Column("CEP")]
        public string CEP { get; set; }
        [Required]
        [Column("LOGRADOURO")]
        public string Logradouro { get; set; }
        [Column("NUMERO")]
        public string Numero { get; set; }
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }
        [Required]
        [Column("BAIRRO")]
        public string Bairro { get; set; }
        [Required]
        [Column("CIDADE")]
        public string Cidade { get; set; }
        [Required]
        [Column("UF")]
        public string UF { get; set; }
    }
}
