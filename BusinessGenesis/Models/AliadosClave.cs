namespace BusinessGenesis.Models
    {
        public class AliadosClaves
        {
            public int Id { get; set; } // Identificador único para cada entrada

            // Pregunta 1: ¿Con qué tipo de socios o aliados necesitas colaborar para que tu negocio funcione?
            public List<string> TipoDeSocios { get; set; } // Lista de respuestas seleccionadas (checkbox)

            // Pregunta 2: ¿Qué funciones o actividades dependen de estos aliados?
            public List<string> FuncionesDeAliados { get; set; } // Lista de respuestas seleccionadas (checkbox)

            // Pregunta 3: ¿Cómo eliges a tus socios o aliados?
            public List<string> CriteriosDeSelecciónDeSocios { get; set; } // Lista de respuestas seleccionadas (checkbox)

            // Pregunta 4: ¿Qué tan dependiente es tu negocio de estos socios clave?
            public string DependenciaDeAliados { get; set; } // Respuesta seleccionada (radio)

            // Pregunta 5: ¿Tus socios actuales están bien alineados con tus objetivos de negocio?
            public string AlineaciónConSocios { get; set; } // Respuesta seleccionada (radio)

            // Pregunta 6: ¿Cómo gestionas la relación con tus socios clave?
            public string GestiónDeRelacionesConSocios { get; set; } // Respuesta seleccionada (select)
        }
    

}
