using System.ComponentModel.DataAnnotations;

namespace Valhahalha_Blazor_Server.Model
{
    public class Comentarios : Generics
    {
        [Required(ErrorMessage ="Este campo não pode estar vazio")]
        public string Comentario { get; set; }
        public virtual Albun AlbunsId { get; set; }
        public int Album { get; set; }
    }
}
