using Valhahalha_Blazor_ServerSide.Model;
using Valhahalha_Blazor_ServerSide.Services.Interfaces;

namespace Valhahalha_Blazor_ServerSide.Services
{
    public class AlbumServices : IAlbunsServices
    {
        private readonly HttpClient _httpClient;

        public AlbumServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Albun>> ListarAlbus()
        {
            var albuns = await _httpClient.GetFromJsonAsync<IEnumerable<Albun>>("api/album");
            return albuns;
        }

        public async Task<Albun> GetById(int id)
        {
            var album = await _httpClient.GetFromJsonAsync<Albun>($"api/album/{id}");
            return album;
        }
        public async Task<Albun> AdicinarAlbum(Albun album)
        {
            var response = await _httpClient.PostAsJsonAsync<Albun>("api/album", album);
            var content = await response.Content.ReadFromJsonAsync<Albun>();
            return content;
        }

        public async Task<Albun> DarLike(int id)
        {
            var response = await _httpClient.PutAsJsonAsync<Albun>($"api/album/{id}", null);
            var content = await response.Content.ReadFromJsonAsync<Albun>();
            return content;
        }


    }
}