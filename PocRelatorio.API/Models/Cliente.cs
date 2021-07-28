using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocRelatorio.API
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CodigoCliente { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int QuantidadeTitulos { get; set; }
        public double TotalPago { get; set; }

        public List<TitulosRenegociados> Titulos { get; set; }
        public List<FormaPagamento> FormaPagamentos { get; set; }
    }
}
