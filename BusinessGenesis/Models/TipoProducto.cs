using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessGenesis.Models
{
    public class TipoProducto
    {
        public int Id { get; set; }

        [ForeignKey("IdNegocio")]
        public int idNegocio {  get; set; }

        public string? nombre { get; set; }

    }
}
