using Microsoft.EntityFrameworkCore;
using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_Server.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Albun> Album { get; set; }

        public DbSet<Comentari> Comentarios { get; set; }


    }
}
