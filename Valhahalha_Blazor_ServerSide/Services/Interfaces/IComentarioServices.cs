using Microsoft.CodeAnalysis.CSharp.Syntax;
using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_ServerSide.Services.Interfaces
{
    public interface IComentarioServices
    {
        Task<IEnumerable<Comentari>> ListarComentarios();
        Task<IEnumerable<Comentari>> GetById (int id);
        Task<Comentari> AdicionarComentario(int id, Comentari comentario);

    }
}
