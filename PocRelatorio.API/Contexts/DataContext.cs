using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace PocRelatorio.API.Contexts
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TitulosRenegociados> Titulos { get; set; }
        public DbSet<FormaPagamento> FormasPagamentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RelatorioDb;Integrated Security=True;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Titulo 1
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, CodigoCliente = 00105, Nome = "Cliente teste", Cnpj = "99.99.999/9999-99", QuantidadeTitulos = 2, TotalPago = 7062.00 });

            modelBuilder.Entity<TitulosRenegociados>().HasData(
                 new TitulosRenegociados { ClienteId = 1, Id = 1, NumeroTituloRenegociado = 123456, Parcela = "A", Vencimento = "01/01/2020", ValorOriginalTitulo = 2000.00, Juros = 20, Multa = 2, ValorAtualizado = 2022.00 },
                 new TitulosRenegociados { ClienteId = 1, Id = 2, NumeroTituloRenegociado = 555559, Parcela = "B", Vencimento = "01/03/2020", ValorOriginalTitulo = 5000, Juros = 35, Multa = 5, ValorAtualizado = 5040.00 }
             );

            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento { ClienteId = 1, Id = 1, DescricaoTipoPagamento = "Cartão de Crédito", Administradora = "VISA", Valor = 1062.00, QuantidadeParcelas = "2x", DataPagamento = "20/04/2021", LancamentoContabil = 1452656, NumeroAutorizacao = 12457, NSU = 785423658 },
                new FormaPagamento { ClienteId = 1, Id = 2, DescricaoTipoPagamento = "Cartão de Crédito", Administradora = "Master", Valor = 6000.00, QuantidadeParcelas = "8x", DataPagamento = "20/04/2021", LancamentoContabil = 1452656, NumeroAutorizacao = 12345, NSU = 15549662 }
            );

            //======================================================================================================================================================
            //Cliente 2
            modelBuilder.Entity<Cliente>().HasData(
                 new Cliente { Id = 2, CodigoCliente = 001752, Nome = "Farmácia A", Cnpj = "88.88.888/8888-88", QuantidadeTitulos = 2, TotalPago = 2022.00 });


            modelBuilder.Entity<TitulosRenegociados>().HasData(
                 new TitulosRenegociados
                 {
                     ClienteId = 2,
                     Id = 3,
                     NumeroTituloRenegociado = 123456,
                     Parcela = "A",
                     Vencimento = "01/01/2020",
                     ValorOriginalTitulo = 2000.00,
                     Juros = 20,
                     Multa = 2,
                     ValorAtualizado = 2022.00
                 }
             );

            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento
                {
                    ClienteId = 2,
                    Id = 3,
                    DescricaoTipoPagamento = "Cartão de Crédito",
                    Administradora = "Master",
                    Valor = 2000.00,
                    QuantidadeParcelas = "2x",
                    DataPagamento = "22/04/2021",
                    LancamentoContabil = 1426587,
                    NumeroAutorizacao = 65251,
                    NSU = 5847562
                }

             );


            //==========================================================================================================================================================
            //Cliente 3

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 3, CodigoCliente = 45879, Nome = "Roupas B", Cnpj = "77.77.777/7777-77", QuantidadeTitulos = 6, TotalPago = 35202.70 });


            modelBuilder.Entity<TitulosRenegociados>().HasData(
                 new TitulosRenegociados
                 {
                     ClienteId = 3,
                     Id = 4,
                     NumeroTituloRenegociado = 152365,
                     Parcela = "A",
                     Vencimento = "25/03/2020",
                     ValorOriginalTitulo = 250,
                     Juros = 5,
                     Multa = 2,
                     ValorAtualizado = 257
                 },
                 new TitulosRenegociados
                 {
                     ClienteId = 3,
                     Id = 5,
                     NumeroTituloRenegociado = 556685,
                     Parcela = "B",
                     Vencimento = "14/07/2020",
                     ValorOriginalTitulo = 3250,
                     Juros = 12,
                     Multa = 3,
                     ValorAtualizado = 3265
                 },
                 new TitulosRenegociados
                 {
                     ClienteId = 3,
                     Id = 6,
                     NumeroTituloRenegociado = 776458,
                     Parcela = "B",
                     Vencimento = "13/05/2020",
                     ValorOriginalTitulo = 745,
                     Juros = 7,
                     Multa = 2.50,
                     ValorAtualizado = 754.50
                 },
                 new TitulosRenegociados
                 {
                     ClienteId = 3,
                     Id = 7,
                     NumeroTituloRenegociado = 574125,
                     Parcela = "D",
                     Vencimento = "15/06/2020",
                     ValorOriginalTitulo = 2300,
                     Juros = 35,
                     Multa = 2.50,
                     ValorAtualizado = 2337.50
                 },
                 new TitulosRenegociados
                 {
                     ClienteId = 3,
                     Id = 8,
                     NumeroTituloRenegociado = 219453,
                     Parcela = "A",
                     Vencimento = "22/03/2021",
                     ValorOriginalTitulo = 25000,
                     Juros = 1500,
                     Multa = 300,
                     ValorAtualizado = 26800
                 }
             );

            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento
                {
                    ClienteId = 3,
                    Id = 4,
                    DescricaoTipoPagamento = "Cartão de Crédito",
                    Administradora = "VISA",
                    Valor = 30000,
                    QuantidadeParcelas = "10X",
                    DataPagamento = "23/04/2021",
                    LancamentoContabil = 1457895,
                    NumeroAutorizacao = 254566,
                    NSU = 48756235
                },
                new FormaPagamento
                {
                    ClienteId = 3,
                    Id = 5,
                    DescricaoTipoPagamento = "PIX",
                    Administradora = "_",
                    Valor = 5202.70,
                    QuantidadeParcelas = "1X",
                    DataPagamento = "23/04/2021",
                    LancamentoContabil = 1457895,
                    NumeroAutorizacao = 0,
                    NSU = 0
                });


            //==============================================================================================================================================================================
            //Cliente 4
            modelBuilder.Entity<Cliente>().HasData(
              new Cliente { Id = 4, CodigoCliente = 001753, Nome = "Farmácia C", Cnpj = "88.88.888/8888-88", QuantidadeTitulos = 2, TotalPago = 812.00 });


            modelBuilder.Entity<TitulosRenegociados>().HasData(
                 new TitulosRenegociados
                 {
                     ClienteId = 4,
                     Id = 9,
                     NumeroTituloRenegociado = 123456,
                     Parcela = "A",
                     Vencimento = "01/01/2020",
                     ValorOriginalTitulo = 500,
                     Juros = 15,
                     Multa = 5,
                     ValorAtualizado = 520
                 },
                 new TitulosRenegociados
                 {
                     ClienteId = 4,
                     Id = 10,
                     NumeroTituloRenegociado = 55559,
                     Parcela = "B",
                     Vencimento = "01/03/2020",
                     ValorOriginalTitulo = 250,
                     Juros = 35,
                     Multa = 7,
                     ValorAtualizado = 292
                 });


            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento
                {
                    ClienteId = 4,
                    Id = 6,
                    DescricaoTipoPagamento = "Cartão de Crédito",
                    Administradora = "Master",
                    Valor = 812,
                    QuantidadeParcelas = "6X",
                    DataPagamento = "23/04/2021",
                    LancamentoContabil = 1245862,
                    NumeroAutorizacao = 551225,
                    NSU = 499654756
                });


        }


    }
}
