using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocRelatorio.API
{
    public class TitulosRenegociados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NumeroTituloRenegociado { get; set; }
        public string Parcela { get; set; }
        public string Vencimento { get; set; }
        public double ValorOriginalTitulo { get; set; }
        public double Juros { get; set; }
        public double Multa { get; set; }
        public double ValorAtualizado { get; set; }

        public int ClienteId { get; set; }

        [Ignore]
        public Cliente Cliente { get; set; }
    }
}
