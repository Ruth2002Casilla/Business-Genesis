namespace BusinessGenesis.Models
{
    public class ActividadesClaves
    {
        public int Id { get; set; } // Identificador único para cada entrada

        // Pregunta 1: ¿Qué actividades son esenciales para que tu negocio funcione?
        public List<string> ActividadesEsenciales { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 2: ¿Qué actividades apoyan directamente tu propuesta de valor?
        public List<string> ActividadesQueApoyanPropuesta { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 3: ¿Qué actividades realizas tú mismo y cuáles delegas?
        public List<string> ActividadesQueRealizoYDelego { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 4: ¿Con qué frecuencia realizas estas actividades clave?
        public string FrecuenciaDeActividades { get; set; } // Respuesta seleccionada (select)

    }
}