namespace BusinessGenesis.Models
{
    public class PropuestaValor
    {
        public int Id { get; set; } 

        // Pregunta 1: ¿Qué problema principal resuelve tu producto o servicio?
        public string ProblemaResuelto { get; set; } // Almacena la respuesta de la opción seleccionada

        // Pregunta 2: ¿Qué beneficios principales ofrece tu producto al cliente?
        public string BeneficiosPrincipales { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 3: ¿Tu propuesta de valor se basa en algo que tus competidores no ofrecen?
        public string Competencia { get; set; } // Opción seleccionada

        // Pregunta 4: ¿Cómo se entrega el valor al cliente?
        public string FormaEntrega { get; set; } // Opción seleccionada

        // Pregunta 5: ¿Qué tan grande es el problema que estás resolviendo para tu cliente?
        public string TamanioProblema { get; set; } // Opción seleccionada
    }

}
