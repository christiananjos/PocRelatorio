using Microsoft.EntityFrameworkCore.Migrations;

namespace PocRelatorio.API.Migrations
{
    public partial class RelatorioDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCliente = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeTitulos = table.Column<int>(type: "int", nullable: false),
                    TotalPago = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormasPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoTipoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Administradora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    QuantidadeParcelas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LancamentoContabil = table.Column<long>(type: "bigint", nullable: false),
                    NumeroAutorizacao = table.Column<long>(type: "bigint", nullable: false),
                    NSU = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormasPagamentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTituloRenegociado = table.Column<int>(type: "int", nullable: false),
                    Parcela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vencimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorOriginalTitulo = table.Column<double>(type: "float", nullable: false),
                    Juros = table.Column<double>(type: "float", nullable: false),
                    Multa = table.Column<double>(type: "float", nullable: false),
                    ValorAtualizado = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titulos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cnpj", "CodigoCliente", "Nome", "QuantidadeTitulos", "TotalPago" },
                values: new object[,]
                {
                    { 1, "99.99.999/9999-99", 105, "Cliente teste", 2, 7062.0 },
                    { 2, "88.88.888/8888-88", 1752, "Farmácia A", 2, 2022.0 },
                    { 3, "77.77.777/7777-77", 45879, "Roupas B", 6, 35202.699999999997 },
                    { 4, "88.88.888/8888-88", 1753, "Farmácia C", 2, 812.0 }
                });

            migrationBuilder.InsertData(
                table: "FormasPagamentos",
                columns: new[] { "Id", "Administradora", "ClienteId", "DataPagamento", "DescricaoTipoPagamento", "LancamentoContabil", "NSU", "NumeroAutorizacao", "QuantidadeParcelas", "Valor" },
                values: new object[,]
                {
                    { 1, "VISA", 1, "20/04/2021", "Cartão de Crédito", 1452656L, 785423658L, 12457L, "2x", 1062.0 },
                    { 2, "Master", 1, "20/04/2021", "Cartão de Crédito", 1452656L, 15549662L, 12345L, "8x", 6000.0 },
                    { 3, "Master", 2, "22/04/2021", "Cartão de Crédito", 1426587L, 5847562L, 65251L, "2x", 2000.0 },
                    { 4, "VISA", 3, "23/04/2021", "Cartão de Crédito", 1457895L, 48756235L, 254566L, "10X", 30000.0 },
                    { 5, "_", 3, "23/04/2021", "PIX", 1457895L, 0L, 0L, "1X", 5202.6999999999998 },
                    { 6, "Master", 4, "23/04/2021", "Cartão de Crédito", 1245862L, 499654756L, 551225L, "6X", 812.0 }
                });

            migrationBuilder.InsertData(
                table: "Titulos",
                columns: new[] { "Id", "ClienteId", "Juros", "Multa", "NumeroTituloRenegociado", "Parcela", "ValorAtualizado", "ValorOriginalTitulo", "Vencimento" },
                values: new object[,]
                {
                    { 1, 1, 20.0, 2.0, 123456, "A", 2022.0, 2000.0, "01/01/2020" },
                    { 2, 1, 35.0, 5.0, 555559, "B", 5040.0, 5000.0, "01/03/2020" },
                    { 3, 2, 20.0, 2.0, 123456, "A", 2022.0, 2000.0, "01/01/2020" },
                    { 4, 3, 5.0, 2.0, 152365, "A", 257.0, 250.0, "25/03/2020" },
                    { 5, 3, 12.0, 3.0, 556685, "B", 3265.0, 3250.0, "14/07/2020" },
                    { 6, 3, 7.0, 2.5, 776458, "B", 754.5, 745.0, "13/05/2020" },
                    { 7, 3, 35.0, 2.5, 574125, "D", 2337.5, 2300.0, "15/06/2020" },
                    { 8, 3, 1500.0, 300.0, 219453, "A", 26800.0, 25000.0, "22/03/2021" },
                    { 9, 4, 15.0, 5.0, 123456, "A", 520.0, 500.0, "01/01/2020" },
                    { 10, 4, 35.0, 7.0, 55559, "B", 292.0, 250.0, "01/03/2020" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormasPagamentos_ClienteId",
                table: "FormasPagamentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Titulos_ClienteId",
                table: "Titulos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormasPagamentos");

            migrationBuilder.DropTable(
                name: "Titulos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
