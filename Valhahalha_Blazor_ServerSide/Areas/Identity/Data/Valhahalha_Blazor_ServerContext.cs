using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Valhahalha_Blazor_ServerSide.Data;

public class Valhahalha_Blazor_ServerContext : IdentityDbContext<IdentityUser>
{
    public Valhahalha_Blazor_ServerContext(DbContextOptions<Valhahalha_Blazor_ServerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public static implicit operator Valhahalha_Blazor_ServerContext(IdentityUser v)
    {
        throw new NotImplementedException();
    }
}
