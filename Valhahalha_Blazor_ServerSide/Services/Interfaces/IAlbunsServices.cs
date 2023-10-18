using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_ServerSide.Services.Interfaces
{
    public interface IAlbunsServices
    {
        Task<IEnumerable<Albun>> ListarAlbus();
        Task<Albun> AdicinarAlbum(Albun album);
        Task<Albun> GetById(int id);
        Task<Albun> DarLike(int id);
    }
}
