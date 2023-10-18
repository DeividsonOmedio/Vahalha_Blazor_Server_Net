using Valhahalha_Blazor_Server.Model;
using Valhahalha_Blazor_Server.Service.interfaces;

namespace Valhahalha_Blazor_Server.Service
{
    public class ComentarioServices : IComentarioServices
    {
        private readonly HttpClient _httpClient;

        public ComentarioServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Comentarios> AdicionarComentario(Comentarios comentario)
        {
            var response = await _httpClient.PostAsJsonAsync<Comentarios>("api/comentario", comentario);
            var content = await response.Content.ReadFromJsonAsync<Comentarios>();
            return content;
        }

        public async Task<IEnumerable<Comentarios>> ListarComentarios()
        {
            var comentarios = await _httpClient.GetFromJsonAsync<IEnumerable<Comentarios>>("api/comentarios");
            return comentarios;
        }
    }
}
