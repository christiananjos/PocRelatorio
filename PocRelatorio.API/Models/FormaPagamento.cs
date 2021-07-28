using AutoMapper.Configuration.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocRelatorio.API
{
    public class FormaPagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DescricaoTipoPagamento { get; set; }
        public string Administradora { get; set; }
        public double Valor { get; set; }
        public string QuantidadeParcelas { get; set; }
        public string DataPagamento { get; set; }
        public long LancamentoContabil { get; set; }
        public long NumeroAutorizacao { get; set; }
        public long NSU { get; set; }

        public int ClienteId { get; set; }
        
        [Ignore]
        public Cliente Cliente { get; set; }
    }


}
