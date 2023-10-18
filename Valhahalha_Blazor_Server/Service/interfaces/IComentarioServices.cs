using Valhahalha_Blazor_Server.Model;

namespace Valhahalha_Blazor_Server.Service.interfaces
{
    public interface IComentarioServices
    {
        Task<IEnumerable<Comentarios>> ListarComentarios();
        Task<Comentarios> AdicionarComentario(Comentarios comentario);
    }
}
