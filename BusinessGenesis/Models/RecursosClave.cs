namespace BusinessGenesis.Models
{
    public class RecursosClaves
    {
        public int Id { get; set; } // Identificador único para cada entrada

        // Pregunta 1: ¿Qué tipo de recursos necesitas para que tu negocio funcione?
        public string TipoDeRecursosNecesarios { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 2: ¿Con cuáles de estos recursos ya cuentas?
        public string RecursosQueYaCuentas { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 3: ¿Qué recursos son esenciales para tu propuesta de valor?
        public string RecursosEsenciales { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 4: ¿Cuáles de estos recursos son más costosos de mantener?
        public string RecursosCostosos { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 5: ¿Cómo podrías optimizar tus recursos actuales?
        public string ComoOptimizarRecursos { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 6: ¿Estás aprovechando al máximo tus recursos disponibles?
        public string AprovechamientoDeRecursos { get; set; } // Respuesta seleccionada (radio)
    }

}
