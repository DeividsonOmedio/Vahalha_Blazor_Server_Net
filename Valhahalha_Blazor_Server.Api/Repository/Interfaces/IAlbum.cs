using Valhahalha_Blazor_Server.Api.Model;
using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_Server.Api.Repository.Interfaces
{
    public interface IAlbum
    {
        Task<IEnumerable<Albun>> ListarAlbus();
        Task<Albun> GetById(int id);
        Task<Albun> AdicinarAlbum(Albun album);
        
        Task<Albun> DarLike(int Id);
    }
}