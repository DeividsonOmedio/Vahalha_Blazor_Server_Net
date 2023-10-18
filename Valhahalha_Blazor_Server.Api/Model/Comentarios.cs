using Valhahalha_Blazor_ServerSide.Data;
using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_Server.Api.Model
{
    public class Comentarios : Generics
    {
        public string Comentario { get; set; }
        public virtual Albun? AlbunsId { get; set; }
        public int? Album { get; set; }
        public string? User { get; set; }
    }
}
