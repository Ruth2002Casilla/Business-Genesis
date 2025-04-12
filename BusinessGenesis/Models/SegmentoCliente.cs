namespace BusinessGenesis.Models
{
    public class SegmentoCliente
    {
        public int Id { get; set; } // Identificador único para cada segmento del cliente

        // Pregunta 1: ¿Quién es tu cliente principal o usuario objetivo?
        public string ClientePrincipal { get; set; } // Almacena la respuesta seleccionada

        // Pregunta 2: ¿A qué grupo demográfico pertenece tu cliente?
        public List<string> GrupoDemografico { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 3: ¿Dónde se encuentra tu cliente?
        public string UbicacionCliente { get; set; } // Almacena la respuesta seleccionada

        // Pregunta 4: ¿Qué características tiene tu cliente ideal?
        public List<string> CaracteristicasCliente { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 5: ¿Qué tan bien conoces a tu cliente?
        public string ConocimientoCliente { get; set; } // Almacena la respuesta seleccionada

        // Pregunta 6: ¿Tu producto o servicio se enfoca en...?
        public string EnfoqueProducto { get; set; } // Almacena la respuesta seleccionada

        // Pregunta 7: ¿Qué necesidades o deseos principales tiene tu cliente?
        public List<string> NecesidadesCliente { get; set; } // Lista de respuestas seleccionadas (checkbox)
    }

}
