using BusinessGenesis.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Data
{
    public class GenesisContex : DbContext
    {
        public GenesisContex(DbContextOptions<GenesisContex> options)
            : base(options)
        {
        }

        // Agrega todos los DbSet de tus modelos aquí
        public DbSet<ActividadesClaves> ActividadesClaves { get; set; }
        public DbSet<AliadosClaves> AliadosClaves { get; set; }
        public DbSet<Canales> Canales { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EstructuraDeCostos> EstructuraDeCostos { get; set; }
        public DbSet<FuenteDeIngresos> FuenteDeIngresos { get; set; }
        public DbSet<Negocio> Negocio { get; set; }
        public DbSet<PropuestaValor> PropuestaValor { get; set; }
        public DbSet<RecursosClaves> RecursosClaves { get; set; }
        public DbSet<RelacionConClientes> RelacionConClientes { get; set; }
        public DbSet<SegmentoCliente> SegmentoCliente { get; set; }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActividadesClaves>(entity =>
            {
                entity.ToTable("ActividadesClaves");

                entity.Property(p => p.ActividadesEsenciales)
                    .HasMaxLength(100);

                entity.Property(p => p.ActividadesQueApoyanPropuesta)
                    .HasMaxLength(100);

                entity.Property(p => p.ActividadesQueRealizoYDelego)
                    .HasMaxLength(100);

                entity.Property(p => p.ActividadesParaAutomatizar)
                    .HasMaxLength(100);

                entity.Property(p => p.FrecuenciaDeActividades)
                    .HasMaxLength(100);

                entity.Property(p => p.DependenciaDeActividadExterna)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AliadosClaves>(entity =>
            {
                entity.Property(e => e.DependenciaDeAliados).HasMaxLength(100);
                entity.Property(e => e.AlineaciónConSocios).HasMaxLength(100);
                entity.Property(e => e.GestiónDeRelacionesConSocios).HasMaxLength(100);

                // Para las listas de respuestas tipo checkbox, utilizamos la conversión a cadena separada por comas
                entity.Property(e => e.TipoDeSocios).HasMaxLength(100);

                entity.Property(e => e.FuncionesDeAliados).HasMaxLength(100);

                entity.Property(e => e.CriteriosDeSelecciónDeSocios).HasMaxLength(100);
            });

            modelBuilder.Entity<Canales>(entity =>
            {
                entity.ToTable("Canales");

                // Convertir las listas a cadenas separadas por comas para almacenarlas en la base de datos
                entity.Property(p => p.CanalesDeEntrada)
                    .HasMaxLength(100);

                entity.Property(p => p.CanalesDeCompra)
                    .HasMaxLength(100);

                entity.Property(p => p.CanalesDeEntrega)
                    .HasMaxLength(100);

                entity.Property(p => p.EficienciaCanales).HasMaxLength(100); // Almacena la eficiencia de los canales
                entity.Property(p => p.CanalPreferido).HasMaxLength(100); // Almacena el canal preferido
                entity.Property(p => p.EficienciaCanales).HasMaxLength(100); // Almacena la eficiencia de los canales

                entity.Property(p => p.EtapasCubiertas)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EstructuraDeCostos>(entity =>
            {
                entity.Property(e => e.ImportanciaDelControlDeCostos).HasMaxLength(100);
                entity.Property(e => e.EstimacionDeCrecimientoDeCostos).HasMaxLength(100);

                entity.Property(e => e.CostosEsenciales).HasMaxLength(100);

                entity.Property(e => e.CostosFijos).HasMaxLength(100);

                entity.Property(e => e.CostosVariables).HasMaxLength(100);

                entity.Property(e => e.EstrategiasDeReduccionDeCostos).HasMaxLength(100);
            });

            modelBuilder.Entity<FuenteDeIngresos>(entity =>
            {
                entity.ToTable("FuenteDeIngresos");

                // Convertir las listas a cadenas separadas por comas para almacenarlas en la base de datos
                entity.Property(p => p.MetodoGeneracionIngresos)
                    .HasMaxLength(100);

                entity.Property(p => p.MetodoPagoClientes)
                    .HasMaxLength(100);

                entity.Property(p => p.TipoIngreso).HasMaxLength(100); // Almacena el tipo de ingreso (radio)
                entity.Property(p => p.IngresosVsCostos).HasMaxLength(100); // Almacena los ingresos vs costos (radio)
                entity.Property(p => p.DisposicionPagoCliente).HasMaxLength(100); // Almacena la disposición de pago del cliente (radio)
                entity.Property(p => p.FuentePrincipalIngresos).HasMaxLength(100); // Almacena la fuente principal de ingresos (select)
            });

            modelBuilder.Entity<Negocio>().HasData(
            new Negocio { Id = 1, TipoDeNegocio = "Colmado" },
            new Negocio { Id = 2, TipoDeNegocio = "Repuesto" },
            new Negocio { Id = 3, TipoDeNegocio = "Supermercado" },
            new Negocio { Id = 4, TipoDeNegocio = "Dealer" },
            new Negocio { Id = 5, TipoDeNegocio = "Ferretería" },
            new Negocio { Id = 6, TipoDeNegocio = "Gimnasio" },
            new Negocio { Id = 7, TipoDeNegocio = "Salón" },
            new Negocio { Id = 8, TipoDeNegocio = "Tienda de Ropa" },
            new Negocio { Id = 9, TipoDeNegocio = "Joyería" },
            new Negocio { Id = 10, TipoDeNegocio = "Farmacia" }
            );

            modelBuilder.Entity<PropuestaValor>(entity =>
            {
                entity.ToTable("PropuestaValor");

                // Definimos que los beneficios principales se almacenan como un campo con un tipo adecuado
                entity.Property(p => p.BeneficiosPrincipales)
                    .HasMaxLength(100);

                // Configuración para las otras propiedades
                entity.Property(p => p.ProblemaResuelto).HasMaxLength(200);
                entity.Property(p => p.Competencia).HasMaxLength(100);
                entity.Property(p => p.FormaEntrega).HasMaxLength(100);
                entity.Property(p => p.TamanioProblema).HasMaxLength(100);
            });

            modelBuilder.Entity<RecursosClaves>(entity =>
            {
                entity.ToTable("RecursosClaves");

                // Convertir las listas a cadenas separadas por comas para almacenarlas en la base de datos
                entity.Property(p => p.TipoDeRecursosNecesarios)
                    .HasMaxLength(100);

                entity.Property(p => p.RecursosQueYaCuentas)
                    .HasMaxLength(100);

                entity.Property(p => p.RecursosEsenciales)
                    .HasMaxLength(100);

                entity.Property(p => p.RecursosCostosos)
                    .HasMaxLength(100);

                entity.Property(p => p.ComoOptimizarRecursos)
                    .HasMaxLength(100);

                entity.Property(p => p.AprovechamientoDeRecursos).HasMaxLength(100); // Almacenar el aprovechamiento de los recursos (radio)
            });

            modelBuilder.Entity<RelacionConClientes>(entity =>
            {
                entity.ToTable("RelacionConClientes");

                // Convertir las listas a cadenas separadas por comas para almacenarlas en la base de datos
                entity.Property(p => p.TipoRelacionEsperada)
                    .HasMaxLength(100);

                entity.Property(p => p.MantenimientoClientes)
                    .HasMaxLength(100);

                entity.Property(p => p.MotivoRecompra).HasMaxLength(100); // Almacena el motivo de recompra (radio)
                entity.Property(p => p.GestionRelacionCliente).HasMaxLength(100); // Almacena la gestión de la relación con el cliente
                entity.Property(p => p.ImportanciaRelacion).HasMaxLength(100); // Almacena la importancia de la relación con el cliente
            });

            modelBuilder.Entity<SegmentoCliente>(entity =>
            {
                entity.ToTable("SegmentoCliente");

                // Convertir las listas a cadenas separadas por comas para almacenarlas en la base de datos
                entity.Property(p => p.GrupoDemografico)
                    .HasMaxLength(100);

                entity.Property(p => p.CaracteristicasCliente)
                    .HasMaxLength(100);

                entity.Property(p => p.NecesidadesCliente)
                    .HasMaxLength(100);

                // Configuración para las otras propiedades
                entity.Property(p => p.ClientePrincipal).HasMaxLength(100);
                entity.Property(p => p.UbicacionCliente).HasMaxLength(100);
                entity.Property(p => p.ConocimientoCliente).HasMaxLength(100);
                entity.Property(p => p.EnfoqueProducto).HasMaxLength(100);
            });

     

        }
    }
}
