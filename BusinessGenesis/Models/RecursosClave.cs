namespace BusinessGenesis.Models
{
    public class RecursosClaves
    {
        public int Id { get; set; } // Identificador único para cada entrada

        // Pregunta 1: ¿Qué tipo de recursos necesitas para que tu negocio funcione?
        public List<string> TipoDeRecursosNecesarios { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 2: ¿Con cuáles de estos recursos ya cuentas?
        public List<string> RecursosQueYaCuentas { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 3: ¿Qué recursos son esenciales para tu propuesta de valor?
        public List<string> RecursosEsenciales { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 4: ¿Cuáles de estos recursos son más costosos de mantener?
        public List<string> RecursosCostosos { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 5: ¿Cómo podrías optimizar tus recursos actuales?
        public List<string> ComoOptimizarRecursos { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 6: ¿Estás aprovechando al máximo tus recursos disponibles?
        public string AprovechamientoDeRecursos { get; set; } // Respuesta seleccionada (radio)
    }

}
