using Microsoft.EntityFrameworkCore;
using Valhahalha_Blazor_Server.Api.Context;
using Valhahalha_Blazor_Server.Api.Model;
using Valhahalha_Blazor_Server.Api.Repository.Interfaces;
using Valhahalha_Blazor_ServerSide.Data;
using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_Server.Api.Repository.Services
{
    public class ComentarioService : IComentarios
    {
        private readonly AppDbContext _context;

        public ComentarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comentari> AdicionarComentario(Comentari novoComentario)
        {
            
            var result = await _context.Album.FirstOrDefaultAsync(x => x.Id == novoComentario.Album);
            if (result == null)
                return null;
            else
                novoComentario.AlbunsId = result;
           
            if (novoComentario != null)
            {
                var response = await _context.Comentarios.AddAsync(novoComentario);
                await _context.SaveChangesAsync();
                return response.Entity;
            }
            return null;
        }

        public async Task<IEnumerable<Comentari>> GetById(int id)
        {

            return (IEnumerable<Comentari>)await _context.Comentarios.Where(x => x.Album == id).AsNoTracking().ToListAsync();
         //   return await _context.Comentarios.Where(x => x.Album == id).AsNoTracking().ToListAsync();
            
        }

        public async Task<IEnumerable<Comentari>> ListarComentarios()
        {
            return (IEnumerable<Comentari>)await _context.Comentarios.AsNoTracking().ToListAsync();
         //   return (IEnumerable<Comentarios>)await _context.Comentarios.AsNoTracking().ToListAsync();
        }
    }
}
