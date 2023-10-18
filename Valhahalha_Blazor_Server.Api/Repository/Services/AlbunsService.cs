using Microsoft.EntityFrameworkCore;
using Valhahalha_Blazor_Server.Api.Context;
using Valhahalha_Blazor_Server.Api.Repository.Interfaces;
using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_Server.Api.Repository.Services
{
    public class AlbunsService : IAlbum
    {
        private readonly AppDbContext _context;

        public  AlbunsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Albun>> ListarAlbus()
        {
            return await _context.Album.AsNoTracking().ToListAsync();
        }

        public async Task<Albun> GetById(int id)
        {
            var result = await _context.Album.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
                return result;
            return null;
        }

        public async Task<Albun> AdicinarAlbum(Albun album)
        {
            var result = await _context.Album.AddAsync(album);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

       

        public async Task<Albun> DarLike(int Id)
        {
            var result = await _context.Album.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                result.Likes += 1;
                _context.Update(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
                    
        }

      
    }
}
