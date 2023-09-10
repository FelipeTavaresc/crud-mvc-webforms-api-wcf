using Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Modelos
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("CD_CLIENTE")]
        public int Id { get; set; }
        [Required]
        [Column("CPF")]
        public string CPF { get; set; }
        [Required]
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("RG")]
        public string RG { get; set; }
        [Column("DATA_EXPEDICAO")]
        public DateTime? DataExpedicao { get; set; }
        [Column("ORGAO_EXPEDICAO")]
        public string OrgaoExpedicao { get; set; }
        [Column("UF")]
        public string UFExpedicao { get; set; }
        [Required]
        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [Column("SEXO")]
        public string TipoSexo { get; set; }
        [Required]
        [Column("ESTADO_CIVIL")]
        public string TipoEstadoCivil { get; set; }
        [ForeignKey("CD_ENDERECO_CLIENTE")]
        public EnderecoCliente EnderecoCliente { get; set; }
    }
}
