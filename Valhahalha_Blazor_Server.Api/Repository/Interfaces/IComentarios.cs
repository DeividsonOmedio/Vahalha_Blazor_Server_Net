
using Valhahalha_Blazor_Server.Api.Model;
using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_Server.Api.Repository.Interfaces
{
    public interface IComentarios
    {
        Task<IEnumerable<Comentari>> ListarComentarios();
        Task<IEnumerable<Comentari>> GetById(int id);
        Task<Comentari> AdicionarComentario(Comentari comentario);
    }
}
