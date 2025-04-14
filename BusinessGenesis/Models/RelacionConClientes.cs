namespace BusinessGenesis.Models
{
    public class RelacionConClientes
    {
        public int Id { get; set; } // Identificador único para cada entrada

        // Pregunta 1: ¿Qué tipo de relación espera tu cliente tener contigo?
        public string TipoRelacionEsperada { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 2: ¿Cómo planeas mantener a tus clientes actuales?
        public string MantenimientoClientes { get; set; } // Lista de respuestas seleccionadas (checkbox)

        // Pregunta 3: ¿Por qué tus clientes volverían a comprarte?
        public string MotivoRecompra { get; set; } // Respuesta seleccionada (radio)

        // Pregunta 4: ¿Cómo gestionas la relación con tus clientes actualmente?
        public string GestionRelacionCliente { get; set; } // Respuesta seleccionada (select)

        // Pregunta 5: ¿Qué tan importante es para tu negocio tener una relación cercana con tus clientes?
        public string ImportanciaRelacion { get; set; } // Respuesta seleccionada (radio)
    }

}
