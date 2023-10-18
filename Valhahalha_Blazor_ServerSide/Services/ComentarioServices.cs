using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Valhahalha_Blazor_ServerSide.Model;
using Valhahalha_Blazor_ServerSide.Services.Interfaces;

namespace Valhahalha_Blazor_ServerSide.Services
{
    public class ComentarioServices : IComentarioServices
    {
        private readonly HttpClient _httpClient;

        const string url = "https://localhost:7075/api/Comentarios/";
        public ComentarioServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        
        public async Task<Comentari> AdicionarComentario(int id, Comentari comentario)
        {
           // var result = await url.PostJsonAsync(comentario);
            var response = await _httpClient.PostAsJsonAsync<Comentari>($"api/Comentarios/{id}", comentario);
            var content = await response.Content.ReadFromJsonAsync<Comentari>();
            return content;
        }

        public async Task<IEnumerable<Comentari>> GetById(int id)
        {
            var comentario = await _httpClient.GetFromJsonAsync<IEnumerable<Comentari>>($"api/comentarios/{id}");
            return comentario;
        }

        public async Task<IEnumerable<Comentari>> ListarComentarios()
        {
            var comentarios = await _httpClient.GetFromJsonAsync<IEnumerable<Comentari>>("api/comentarios");
            return comentarios;
        }
    }
}