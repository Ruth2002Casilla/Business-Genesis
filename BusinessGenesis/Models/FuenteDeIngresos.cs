namespace BusinessGenesis.Models
{
    public class FuenteDeIngresos
    {
        public int Id { get; set; } // Identificador único para cada entrada

        // Pregunta 1: ¿De qué manera vas a generar ingresos?
        public List<string> MetodoGeneracionIngresos { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 2: ¿Cómo pagan los clientes?
        public List<string> MetodoPagoClientes { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 3: ¿Tus ingresos son constantes o variables?
        public string TipoIngreso { get; set; } // Respuesta seleccionada (radio)

        // Pregunta 4: ¿Tus ingresos actuales o proyectados cubren tus costos?
        public string IngresosVsCostos { get; set; } // Respuesta seleccionada (radio)

        // Pregunta 5: ¿Qué tan dispuesto está tu cliente a pagar por tu solución?
        public string DisposicionPagoCliente { get; set; } // Respuesta seleccionada (radio)

        // Pregunta 6: ¿Cuál será tu fuente principal de ingresos?
        public string FuentePrincipalIngresos { get; set; } // Respuesta seleccionada (select)
    }

}
