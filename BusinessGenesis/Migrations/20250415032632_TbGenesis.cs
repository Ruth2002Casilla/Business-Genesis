using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessGenesis.Migrations
{
    /// <inheritdoc />
    public partial class TbGenesis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActividadesClaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActividadesEsenciales = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ActividadesQueApoyanPropuesta = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ActividadesQueRealizoYDelego = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FrecuenciaDeActividades = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ActividadesParaAutomatizar = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DependenciaDeActividadExterna = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesClaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AliadosClaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoDeSocios = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FuncionesDeAliados = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CriteriosDeSelecciónDeSocios = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DependenciaDeAliados = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AlineaciónConSocios = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GestiónDeRelacionesConSocios = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AliadosClaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Canales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CanalesDeEntrada = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CanalesDeCompra = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CanalesDeEntrega = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CanalPreferido = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EficienciaCanales = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EtapasCubiertas = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstructuraDeCostos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CostosEsenciales = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CostosFijos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CostosVariables = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EstrategiasDeReduccionDeCostos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ImportanciaDelControlDeCostos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EstimacionDeCrecimientoDeCostos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstructuraDeCostos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuenteDeIngresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MetodoGeneracionIngresos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MetodoPagoClientes = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TipoIngreso = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IngresosVsCostos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DisposicionPagoCliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FuentePrincipalIngresos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuenteDeIngresos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Negocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoDeNegocio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negocio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropuestaValor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProblemaResuelto = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    BeneficiosPrincipales = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Competencia = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FormaEntrega = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TamanioProblema = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropuestaValor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecursosClaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoDeRecursosNecesarios = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RecursosQueYaCuentas = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RecursosEsenciales = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RecursosCostosos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ComoOptimizarRecursos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AprovechamientoDeRecursos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursosClaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelacionConClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoRelacionEsperada = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MantenimientoClientes = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MotivoRecompra = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GestionRelacionCliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ImportanciaRelacion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionConClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SegmentoCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientePrincipal = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GrupoDemografico = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UbicacionCliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CaracteristicasCliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ConocimientoCliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EnfoqueProducto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NecesidadesCliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentoCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idNegocio = table.Column<int>(type: "INTEGER", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProductos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Negocio",
                columns: new[] { "Id", "TipoDeNegocio" },
                values: new object[,]
                {
                    { 1, "Colmado" },
                    { 2, "Repuesto" },
                    { 3, "Supermercado" },
                    { 4, "Dealer" },
                    { 5, "Ferretería" },
                    { 6, "Gimnasio" },
                    { 7, "Salón" },
                    { 8, "Tienda de Ropa" },
                    { 9, "Joyería" },
                    { 10, "Farmacia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadesClaves");

            migrationBuilder.DropTable(
                name: "AliadosClaves");

            migrationBuilder.DropTable(
                name: "Canales");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "EstructuraDeCostos");

            migrationBuilder.DropTable(
                name: "FuenteDeIngresos");

            migrationBuilder.DropTable(
                name: "Negocio");

            migrationBuilder.DropTable(
                name: "PropuestaValor");

            migrationBuilder.DropTable(
                name: "RecursosClaves");

            migrationBuilder.DropTable(
                name: "RelacionConClientes");

            migrationBuilder.DropTable(
                name: "SegmentoCliente");

            migrationBuilder.DropTable(
                name: "TipoProductos");
        }
    }
}
