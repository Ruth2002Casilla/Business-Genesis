using BusinessGenesis.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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
        public DbSet<TipoProducto> TipoProducto { get; set; }



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

            modelBuilder.Entity<TipoProducto>().HasData(
            new TipoProducto
      {
          Id = 1,
          Colmado = string.Join(", ",
              "Arroz",
              "Habichuelas (secas o enlatadas)",
              "Aceite",
              "Sal y azúcar",
              "Harina de maíz / trigo",
              "Sopitas (caldos en cubitos)",
              "Sardinas y atún enlatado",
              "Salami y jamoneta",
              "Pan (sobao o de agua)",
              "Huevos",
              "Leche en polvo o líquida",
              "Café y cacao",
              "Espaguetis y otros tipos de pastas",
              "Galletas (sodas, dulces, de leche)",
              "Chicharrones de fundita",
              "Papitas (frituras)",
              "Chocolates",
              "Caramelos",
              "Bizcochitos",
              "Juguitos en fundita o cajita",
              "Refrescos y cervezas",
              "Detergente (en polvo o líquido)",
              "Cloro",
              "Suavizante",
              "Jabón de cuaba y de baño",
              "Papel higiénico",
              "Toallas sanitarias",
              "Pasta dental y cepillos",
              "Desodorante"
          )
      },
            new TipoProducto
      {
          Id = 2,
          Repuesto = string.Join(", ",
              "Pastillas de freno",
              "Discos de freno",
              "Tambores de freno",
              "Amortiguadores",
              "Bujías",
              "Filtros de aceite",
              "Filtros de aire",
              "Filtros de combustible",
              "Filtros de cabina",
              "Bombas de agua",
              "Bombas de gasolina",
              "Correas de distribución",
              "Correas de alternador",
              "Radiadores",
              "Mangueras",
              "Termostatos",
              "Baterías",
              "Alternadores",
              "Motor de arranque",
              "Relés",
              "Fusibles",
              "Bombillos halógenos",
              "Bombillos LED",
              "Faroles",
              "Interruptores",
              "Sensores",
              "Cables de bujía",
              "Retrovisores",
              "Manillas de puertas",
              "Parrillas",
              "Parachoques",
              "Guardafangos",
              "Tapas plásticas",
              "Limpiavidrios",
              "Emblemas",
              "Calcomanías",
              "Aceite de motor mineral",
              "Aceite semi sintético",
              "Aceite sintético",
              "Coolant",
              "Grasa",
              "Aditivos para gasolina",
              "Aditivos para aceite",
              "Limpiador de inyectores",
              "Silicón",
              "Teflón",
              "Pega para juntas",
              "Limpiavidrios",
              "Shampoo para autos",
              "Cera para autos",
              "Llaves de cruz",
              "Llaves tipo T",
              "Llaves inglesas",
              "Gatas hidráulicas",
              "Infladores de aire portátiles",
              "Probadores de batería",
              "Tuercas",
              "Tornillos",
              "Tapas de válvula",
              "Gomas para puertas",
              "Extintores",
              "Bocinas",
              "Kit de emergencia"
          )
      },
             new TipoProducto
      {
          Id = 3,
          Supermercado = string.Join(", ",
              "Arroz",
              "Habichuelas",
              "Aceite",
              "Azúcar",
              "Sal",
              "Harina",
              "Sopitas",
              "Sardinas",
              "Atún",
              "Jamón",
              "Salami",
              "Pan",
              "Huevos",
              "Leche",
              "Yogurt",
              "Mantequilla",
              "Margarina",
              "Queso",
              "Café",
              "Cacao",
              "Galletas",
              "Galletas saladas",
              "Fideos",
              "Espaguetis",
              "Lentejas",
              "Frijoles",
              "Pasta",
              "Cereales",
              "Jugos",
              "Refrescos",
              "Bebidas alcohólicas",
              "Snacks",
              "Chocolates",
              "Helados",
              "Frutas",
              "Verduras",
              "Tomates",
              "Papas",
              "Plátanos",
              "Cebollas",
              "Ajo",
              "Limones",
              "Aceitunas",
              "Pimientos",
              "Salsas",
              "Pasta de dientes",
              "Jabón",
              "Detergente",
              "Suavizante de ropa",
              "Cloro",
              "Papel higiénico",
              "Toallas sanitarias",
              "Pañuelos de papel",
              "Servilletas",
              "Toallas de cocina",
              "Bolsas plásticas",
              "Limpiadores multiusos",
              "Platos desechables",
              "Vasos desechables",
              "Cubiertos desechables",
              "Aceite para freír",
              "Productos para bebés",
              "Juguetes",
              "Perfumes",
              "Desodorantes",
              "Gel antibacterial",
              "Crema para manos",
              "Cosméticos",
              "Razuradoras",
              "Champú y acondicionador",
              "Jabones líquidos",
              "Productos de limpieza",
              "Papel aluminio",
              "Papel film",
              "Vino",
              "Café en cápsulas"
          )
      },
             new TipoProducto
      {
          Id = 4,
          Dealer = string.Join(", ",
              "Vehículos nuevos",
              "Vehículos usados",
              "Vehículos de lujo",
              "Motocicletas",
              "Camiones de carga",
              "Vehículos eléctricos",
              "Automóviles híbridos",
              "Accesorios para vehículos",
              "Llantas",
              "Rines",
              "Filtros de aire y aceite",
              "Pastillas de freno",
              "Discos de freno",
              "Amortiguadores",
              "Bujías",
              "Bombillos de faros",
              "Aceite para motor",
              "Líquido de frenos",
              "Líquido de transmisión",
              "Líquido anticongelante",
              "Líquido limpiaparabrisas",
              "Baterías de automóvil",
              "Correas de distribución",
              "Correas de alternador",
              "Termostatos",
              "Kits de herramientas para vehículos",
              "Equipos de diagnóstico automotriz",
              "Elevadores hidráulicos",
              "Asientos para vehículos",
              "Cargadores de batería portátiles",
              "Alarmas y sistemas de seguridad para vehículos",
              "Radios y sistemas de audio",
              "Cámaras de reversa",
              "Sensores de parqueo",
              "Kits de instalación de accesorios",
              "Cubiertas de coche",
              "Protector de pintura",
              "Servicio de mantenimiento preventivo",
              "Inspección de vehículos",
              "Cambio de llantas y alineación",
              "Reparación de carrocería y pintura",
              "Diagnóstico y reparación de sistemas electrónicos del vehículo",
              "Instalación de GPS y otros dispositivos",
              "Servicio de detalles y limpieza profunda de vehículos",
              "Financiación de vehículos",
              "Seguros para vehículos",
              "Garantías extendidas para vehículos nuevos y usados",
              "Repuestos originales del fabricante",
              "Documentación para la compra",
              "Test drive",
              "Servicios de entrega a domicilio del vehículo",
              "Servicio postventa"
          )
      },
            new TipoProducto
      {
          Id = 5,
          Ferreteria = string.Join(", ",
              "Martillos",
              "Destornilladores",
              "Llaves inglesas",
              "Llaves de vaso",
              "Pinzas",
              "Cinceles",
              "Sierras",
              "Brocas",
              "Taladros",
              "Lijadoras",
              "Picos",
              "Palas",
              "Rastrillos",
              "Escobas",
              "Trapeadores",
              "Cubos",
              "Guantes de trabajo",
              "Máscaras de protección",
              "Gafas de seguridad",
              "Cascos de protección",
              "Cinta métrica",
              "Nivel",
              "Escuadra",
              "Clavos y tornillos",
              "Tuercas y arandelas",
              "Perfiles metálicos",
              "Hilos y cuerdas",
              "Pegamento",
              "Cinta adhesiva",
              "Selladores",
              "Pinturas y esmaltes",
              "Brochas, pinceles y rodillos",
              "Barnices y lacas",
              "Lijas y esponjas abrasivas",
              "Discos de corte y lijado",
              "Tubos y conexiones de PVC",
              "Mangueras",
              "Grifos y válvulas",
              "Bombillos y focos",
              "Bombas de agua",
              "Interruptores y enchufes",
              "Cable eléctrico",
              "Tomas de corriente",
              "Cables de extensión",
              "Fusibles",
              "Alicates",
              "Herramientas para soldar",
              "Soldaduras y alambres de soldar",
              "Cadenas y candados",
              "Cerraduras",
              "Ganchos y perchas",
              "Clavos para concreto y madera",
              "Adornos y decoraciones para exteriores",
              "Accesorios para baño",
              "Plomería",
              "Herramientas para jardinería",
              "Fertilizantes y pesticidas",
              "Semillas y plantas en macetas",
              "Riego",
              "Equipos de seguridad",
              "Materiales para construcción",
              "Adhesivos para pisos y cerámica",
              "Pisos y cerámica",
              "Estufas, calderas y accesorios para gas",
              "Equipo de soldadura",
              "Productos para impermeabilización",
              "Escaleras",
              "Andamios",
              "Compresores de aire",
              "Generadores eléctricos",
              "Herramientas para carpintería",
              "Herramientas para pintura",
              "Productos para limpieza industrial",
              "Limpiadores de metales y madera",
              "Productos de ferretería para automóviles"
          )
      },
            new TipoProducto
      {
          Id = 6,
          Gimnasio = string.Join(", ",
              "Pesas libres",
              "Mancuernas",
              "Barras de pesas",
              "Discos de pesas",
              "Bancos de pesas",
              "Máquinas de pesas (para diferentes grupos musculares)",
              "Bicicletas estáticas",
              "Caminadoras",
              "Elípticas",
              "Remadoras",
              "Máquinas de step",
              "Máquinas de abdominales",
              "Máquinas de glúteos",
              "Prensa de piernas",
              "Máquinas de espalda",
              "Máquinas de pecho",
              "Cuerdas para saltar",
              "Esteras de yoga",
              "Balones de estabilidad",
              "Kettlebells",
              "Bandas de resistencia",
              "Pesas rusas",
              "Sillas para abdominales",
              "Esteras para ejercicios",
              "Cajones de pliometría",
              "Pelotas medicinales",
              "Barras para dominadas",
              "Equipos de pilates",
              "Esteras para pilates",
              "Máquinas de cardio (de todo tipo)",
              "Ruedas para abdominales",
              "Pesas para tobillos",
              "Pesas para muñecas",
              "Trampolines de fitness",
              "Sacos de boxeo",
              "Guantes de boxeo",
              "Cojines para ejercicios de suelo",
              "Gimnasios de resistencia elástica",
              "Entrenadores de suspensión (TRX)",
              "Accesorios para estiramientos",
              "Rodillos de espuma (foam rollers)",
              "Discos de equilibrio",
              "Ruedas de equilibrio",
              "Pesas de arrastre",
              "Estantes para almacenamiento de pesas",
              "Cinturones para levantar pesas",
              "Rodilleras y muñequeras de soporte",
              "Zapatillas deportivas para entrenamiento",
              "Camisetas y pantalones deportivos",
              "Ropa de compresión",
              "Botellas de agua",
              "Toallas para gimnasio",
              "Suplementos alimenticios",
              "Proteínas en polvo",
              "Bebidas energéticas",
              "Creatina",
              "Aminoácidos",
              "Multivitamínicos",
              "Guantes para entrenamiento",
              "Equipos para rehabilitación",
              "Bandas para estiramientos",
              "Almohadillas para pesas",
              "Dispositivos de monitoreo de frecuencia cardíaca",
              "Máquinas de análisis de composición corporal",
              "Auriculares deportivos",
              "Relojes deportivos",
              "Equipos de masaje para recuperación muscular",
              "Crema para masajes",
              "Bálsamos musculares",
              "Suplementos para la hidratación",
              "Cámaras de ejercicio de bajo impacto (para recuperación)",
              "Camas de masaje",
              "Cámaras de crioterapia"
          )
      },
            new TipoProducto
      {
          Id = 7,
          Salon = string.Join(", ",
              "Secadores de cabello",
              "Planchas de cabello",
              "Rizos (máquinas para rizos)",
              "Cortadoras de cabello",
              "Cepillos para cabello",
              "Peines (de diferentes tamaños y tipos)",
              "Tenacillas",
              "Cepillos térmicos",
              "Secadores de uñas",
              "Lamparas UV y LED (para uñas)",
              "Limpiadores de uñas",
              "Cortauñas",
              "Pinceles para uñas",
              "Esmaltes de uñas",
              "Esmaltes semi permanentes",
              "Removedores de esmalte",
              "Aceites para uñas",
              "Crema para cutículas",
              "Hidratantes para manos y pies",
              "Exfoliantes para manos y pies",
              "Limas de uñas",
              "Planchas de depilación",
              "Cera depilatoria",
              "Máquinas para depilación (eléctricas, de cera, etc.)",
              "Crema para depilación",
              "Pinzas",
              "Parches depilatorios",
              "Cremas para afeitar",
              "Peines para barba y bigote",
              "Crema para afeitar",
              "Espuma de afeitar",
              "Mascarillas faciales",
              "Crema hidratante para la cara",
              "Tónicos faciales",
              "Aceites esenciales",
              "Limpiadores faciales",
              "Sérums faciales",
              "Contorno de ojos",
              "Exfoliantes faciales",
              "Productos antiarrugas",
              "Crema para cicatrices",
              "Tratamientos para el acné",
              "Hidratantes para cuerpo",
              "Jabón de baño",
              "Aceites corporales",
              "Gel de baño",
              "Toallas faciales",
              "Toallas para el cuerpo",
              "Esteras de yoga",
              "Masajes (máquinas o a mano)",
              "Cremas para masajes",
              "Cajas de masaje",
              "Productos para el cabello",
              "Tratamientos para el cabello",
              "Ampollas reparadoras para el cabello",
              "Mascarillas para el cabello",
              "Tintes para el cabello",
              "Devolución de color para el cabello",
              "Productos para alisar el cabello",
              "Productos para rizar el cabello",
              "Champú seco",
              "Aceites para el cabello",
              "Lacas para el cabello",
              "Geles para el cabello",
              "Espumas para el cabello",
              "Brillos para el cabello",
              "Ceras para el cabello",
              "Cremas para peinar",
              "Lacas fijadoras",
              "Cuidado de la piel",
              "Tratamientos corporales",
              "Ácido hialurónico",
              "Jabón para rostro",
              "Exfoliantes corporales",
              "Geles para contorno de ojos",
              "Lentes de protección",
              "Ropa de trabajo",
              "Sillas ergonómicas",
              "Camillas para tratamientos faciales",
              "Sillas de pedicura",
              "Mesas para manicura",
              "Lámparas para manicura y pedicura",
              "Aparatos para tratamientos faciales",
              "Aparatos para masajes faciales",
              "Esterilizadores para herramientas",
              "Toallitas desinfectantes",
              "Cinta adhesiva para depilación",
              "Papel depilatorio",
              "Guantes de látex",
              "Vaporizadores para la piel",
              "Dispensadores de alcohol",
              "Aromatizantes para el salón"
          )
      },
            new TipoProducto
       {
           Id = 8,
           TiendaRopa = string.Join(", ",
              "Camisetas",
              "Camisas",
              "Blusas",
              "Pantalones",
              "Jeans",
              "Faldas",
              "Shorts",
              "Chaquetas",
              "Abrigos",
              "Suéteres",
              "Cardigans",
              "Bikinis",
              "Trajes de baño",
              "Ropa interior",
              "Pijamas",
              "Ropa deportiva",
              "Leggings",
              "Ropa de maternidad",
              "Ropa para niños",
              "Vestidos",
              "Faldas largas",
              "Túnicas",
              "Chalecos",
              "Cárdigans",
              "Bufandas",
              "Gorros",
              "Sombreros",
              "Guantes",
              "Cinturones",
              "Lentes de sol",
              "Zapatos",
              "Botas",
              "Zapatillas deportivas",
              "Sandalias",
              "Tacones",
              "Mocasines",
              "Botines",
              "Tenis",
              "Pantuflas",
              "Bolsos",
              "Carteras",
              "Mochilas",
              "Maletines",
              "Relojes",
              "Joyería",
              "Pantalones deportivos",
              "Ropa de trabajo",
              "Chalecos reflectantes",
              "Trajes formales",
              "Trajes de gala",
              "Corbatas",
              "Pajaritas",
              "Pañuelos",
              "Camisones",
              "Batas de baño",
              "Lencería",
              "Medias",
              "Calcetines",
              "Ropa térmica",
              "Gafas de sol",
              "Paraguas",
              "Maletas de viaje",
              "Equipaje de mano",
              "Ropa de cama",
              "Trajes de esquí o de nieve",
              "Ropa para actividad al aire libre",
              "Prendas con tecnología",
              "Prendas de algodón orgánico",
              "Ropa de marcas específicas",
              "Ropa de colección limitada o edición especial",
              "Pantalones de mezclilla",
              "Pantalones de tela",
              "Chaquetas de mezclilla",
              "Cazadoras",
              "Blazers",
              "Camisetas con estampados",
              "Ropa para eventos especiales",
              "Ropa de lujo o alta costura",
              "Terceras capas",
              "Vestidos de cóctel",
              "Trajes de baño de una pieza o bikinis",
              "Chalecos acolchonados",
              "Pantalones cargo",
              "Camisetas sin mangas",
              "Tops y crop tops",
              "Ropa vintage"
          )
       },
            new TipoProducto
      {
          Id = 9,
          Joyeria = string.Join(", ",
              "Anillos",
              "Pulseras",
              "Collares",
              "Pendientes",
              "Broches",
              "Cadenas",
              "Relojes",
              "Argollas de matrimonio",
              "Alianzas de boda",
              "Charms",
              "Brazaletes",
              "Anillos de compromiso",
              "Pendientes de diamantes",
              "Joyas personalizadas",
              "Anillos de piedras preciosas",
              "Collares con medallas",
              "Cierres de joyas",
              "Joyería de plata",
              "Joyería de oro",
              "Joyería de platino",
              "Joyería de acero inoxidable",
              "Joyería de cobre",
              "Piedras preciosas",
              "Perlas",
              "Joyas con gemas semipreciosas",
              "Cajas de joyería",
              "Cadenas de oro",
              "Cadenas de plata",
              "Pendientes de perlas",
              "Broches de fantasía",
              "Joyería de fantasía",
              "Tiendas de relojes de lujo",
              "Relojes de pulsera",
              "Relojes de bolsillo",
              "Joyería para hombre",
              "Gemelos",
              "Alfileres de corbata",
              "Anillos de sello",
              "Diademas",
              "Tiara de novia",
              "Joyería para niños",
              "Joyería vintage",
              "Joyería de diseño exclusivo",
              "Joyería artesanal",
              "Cajas y estuches para anillos",
              "Pulseras con piedras preciosas",
              "Pendientes de oro",
              "Pendientes de plata",
              "Joyas de colección",
              "Anillos de bodas con diamantes",
              "Joyería con diamantes certificados",
              "Gemas y cristales para joyería",
              "Reparación de joyas",
              "Limpieza de joyas",
              "Joyas personalizadas con grabado",
              "Anillos de compromiso con diamantes",
              "Joyería con piedras naturales",
              "Joyería con esmeraldas",
              "Joyería con rubíes",
              "Joyería con zafiros",
              "Joyería con ágatas",
              "Joyería con topacios",
              "Joyería con amatistas",
              "Joyería con citrinos",
              "Joyería con ónix",
              "Joyería con turquesas",
              "Joyería con jade"
          )
      },
            new TipoProducto
      {
          Id = 10,
          Farmacia = string.Join(", ",
              "Medicamentos de prescripción",
              "Medicamentos sin prescripción",
              "Analgésicos",
              "Antiinflamatorios",
              "Antibióticos",
              "Antihistamínicos",
              "Vitaminas",
              "Minerales",
              "Suplementos alimenticios",
              "Pastillas para el resfriado",
              "Jarabes para la tos",
              "Gotas para los ojos",
              "Gotas para los oídos",
              "Pomadas",
              "Crema para quemaduras",
              "Crema para la piel",
              "Cremas antibióticas",
              "Ungüentos",
              "Productos para el acné",
              "Desinfectantes",
              "Alcohol",
              "Algodón",
              "Gasas",
              "Vendas",
              "Esparadrapo",
              "Termómetros",
              "Tiras reactivas para glucosa",
              "Jeringas",
              "Agujas",
              "Batas de hospital",
              "Guantes desechables",
              "Mascarillas",
              "Tiras para control de colesterol",
              "Productos para el cuidado del cabello",
              "Champú",
              "Acondicionadores",
              "Lociones para el cuero cabelludo",
              "Cepillos para el cabello",
              "Peines",
              "Lentes de contacto",
              "Soluciones para lentes de contacto",
              "Gotas para los ojos",
              "Pastillas para el sueño",
              "Antiácidos",
              "Productos para la digestión",
              "Laxantes",
              "Productos para la diarrea",
              "Suplementos para el sistema inmunológico",
              "Productos para la piel seca",
              "Protector solar",
              "Repelentes de insectos",
              "Desodorantes",
              "Higiene íntima",
              "Toallas higiénicas",
              "Protectores diarios",
              "Jabones antibacterianos",
              "Pasta de dientes",
              "Cepillos de dientes",
              "Enjuagues bucales",
              "Hilo dental",
              "Productos para el cuidado de la boca",
              "Parche para el dolor",
              "Cremas para la artritis",
              "Parches para la fiebre",
              "Tratamientos para hongos",
              "Crema para pies",
              "Geles para masaje",
              "Inhaladores",
              "Dispositivos para medir la presión arterial",
              "Termómetros digitales",
              "Humidificadores",
              "Productos para la alergia",
              "Descongestionantes nasales",
              "Vaporizadores",
              "Productos para la salud del corazón",
              "Tónicos para el sistema nervioso",
              "Antidepresivos",
              "Antipsicóticos",
              "Analgésicos tópicos",
              "Suplementos para el cabello",
              "Suplementos para las uñas",
              "Suplementos para la piel",
              "Cremas antiarrugas",
              "Medicamentos para la hipertensión",
              "Anticonceptivos",
              "Test de embarazo",
              "Test de ovulación",
              "Tratamientos para la tos y resfriado",
              "Medicamentos para la fiebre",
              "Enemas",
              "Productos para heridas",
              "Comodines de baño",
              "Suplementos para la memoria",
              "Medicamentos para el colesterol",
              "Productos ortopédicos",
              "Bastones",
              "Muletas",
              "Andadores",
              "Sillas de ruedas",
              "Protectores para la piel",
              "Pomadas para dolores musculares",
              "Parche térmico"
          )
      },
            new TipoProducto
      {
          Id = 11,
          Zapateria = string.Join(", ",
              "Zapatos de hombre",
              "Zapatos de mujer",
              "Zapatos para niños",
              "Botas",
              "Botines",
              "Sandalias",
              "Zapatillas deportivas",
              "Mocasines",
              "Tacones",
              "Alpargatas",
              "Bailarinas",
              "Zapatillas de casa",
              "Zapatillas de baño",
              "Sandalias planas",
              "Botas de lluvia",
              "Botas de montaña",
              "Botas de cuero",
              "Zapatos de vestir",
              "Zapatos informales",
              "Zapatillas de running",
              "Zapatillas de entrenamiento",
              "Calzado de trabajo",
              "Zapatos ortopédicos",
              "Calzado deportivo",
              "Botas de nieve",
              "Zapatillas de skate",
              "Zapatos de tacón alto",
              "Zapatos de tacón bajo",
              "Zapatos de plataforma",
              "Zapatillas de gimnasio",
              "Zapatillas casuales",
              "Zapatos con velcro",
              "Calzado infantil",
              "Calzado para bebé",
              "Zapatillas de charol",
              "Zapatos de charol",
              "Zapatos de ante",
              "Sandalias de cuña",
              "Sandalias de tacón",
              "Calzado de verano",
              "Calzado de invierno",
              "Zapatos de fiesta",
              "Zapatos de boda",
              "Zapatos de oficina",
              "Zapatos de trabajo",
              "Botas de equitación",
              "Zapatillas con luces (para niños)",
              "Zapatos de trekking",
              "Zapatos de senderismo",
              "Calzado de fútbol",
              "Calzado de baloncesto",
              "Zapatillas de tenis",
              "Calzado de ciclismo",
              "Plantillas ortopédicas",
              "Plantillas para zapatos",
              "Cordones de zapatos",
              "Estuches para zapatos",
              "Bolsas para zapatos",
              "Protector de zapatos",
              "Cera para zapatos",
              "Limpiadores para calzado",
              "Cepillos para zapatos",
              "Crema para zapatos",
              "Calzadores",
              "Zapatos de invierno con forro",
              "Zapatos de piel",
              "Zapatos de goma",
              "Zapatillas de lona",
              "Calzado de trabajo resistente",
              "Zapatos impermeables",
              "Calzado de seguridad",
              "Zapatos para diabéticos",
              "Zapatillas deportivas para correr",
              "Zapatillas de fútbol sala",
              "Zapatos de golf",
              "Zapatos de ballet",
              "Zapatillas de yoga"
          )
      }
  );

        }
    }
}
