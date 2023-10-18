using Valhahalha_Blazor_Server.Model;

namespace Valhahalha_Blazor_Server.Service.interfaces
{
    public interface IAlbunsServices
    {
        Task<IEnumerable<Albun>> ListarAlbus();
        Task<Albun> AdicinarAlbum(Albun album);
        Task<Albun> GetById(int id);
        Task<Albun> DarLike(Albun album);
    }
}
