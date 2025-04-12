namespace BusinessGenesis.Models
{
    public class ActividadesClaves
    {
        public int Id { get; set; }

        // Pregunta 1
        public List<string> ActividadesEsenciales { get; set; }

        // Pregunta 2
        public List<string> ActividadesQueApoyanPropuesta { get; set; }

        // Pregunta 3
        public List<string> ActividadesQueRealizoYDelego { get; set; }

        // Pregunta 4
        public string FrecuenciaDeActividades { get; set; }

        // Pregunta 5 - Actividades que se pueden automatizar
        public List<string> ActividadesParaAutomatizar { get; set; }

        // Pregunta 6 - Dependencia externa
        public string DependenciaDeActividadExterna { get; set; }
    }
}