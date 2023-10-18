using System.ComponentModel.DataAnnotations;
using Valhahalha_Blazor_ServerSide.Data;

namespace Valhahalha_Blazor_ServerSide.Model
{
    public class Comentari : Generics
    {
        [Required(ErrorMessage = "Este campo não pode estar vazio")]
        public string Comentario { get; set; }
        public virtual Albun? AlbunsId { get; set; }
        public int? Album { get; set; }
        public string? User { get; set; }
    }
}
