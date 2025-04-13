namespace BusinessGenesis.Models
{
    public class Canales
    {
        public int Id { get; set; } // Identificador único para cada entrada de canales

        // Pregunta 1: ¿Cómo se enteran tus clientes de tu producto o servicio?
        public string CanalesDeEntrada { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 2: ¿Dónde compran o adquieren tu producto?
        public string CanalesDeCompra { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 3: ¿Cómo entregas tu producto o servicio al cliente?
        public string CanalesDeEntrega { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 4: ¿Qué canal prefieren tus clientes?
        public string CanalPreferido { get; set; } // Respuesta seleccionada (radio)

        // Pregunta 5: ¿Qué tan eficientes son tus canales actuales?
        public string EficienciaCanales { get; set; } // Respuesta seleccionada (radio)

        // Pregunta 6: ¿Qué etapa cubren tus canales actualmente?
        public string EtapasCubiertas { get; set; } // Lista de respuestas seleccionadas (checkbox)
    }

}
