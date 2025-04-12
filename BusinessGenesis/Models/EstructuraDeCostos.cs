namespace BusinessGenesis.Models
{
    public class EstructuraDeCostos
    {
        public int Id { get; set; } // Identificador único para cada entrada

        // Pregunta 1: ¿Cuáles de estos costos son esenciales para operar tu negocio?
        public List<string> CostosEsenciales { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 2: ¿Qué costos fijos tienes en tu negocio?
        public List<string> CostosFijos { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 3: ¿Qué costos variables dependen de la demanda de tus productos o servicios?
        public List<string> CostosVariables { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 4: ¿Cómo planeas reducir o optimizar estos costos?
        public List<string> EstrategiasDeReduccionDeCostos { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 5: ¿Qué tan importante es controlar estos costos para la viabilidad de tu negocio?
        public string ImportanciaDelControlDeCostos { get; set; } // Respuesta seleccionada (radio)

        // Pregunta 6: ¿Cómo estimas que crecerán tus costos en el futuro?
        public string EstimacionDeCrecimientoDeCostos { get; set; } // Respuesta seleccionada (radio)
    }
}
