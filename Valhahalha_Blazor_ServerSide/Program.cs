using Valhahalha_Blazor_ServerSide.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Valhahalha_Blazor_ServerSide.Services;
using Valhahalha_Blazor_ServerSide.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Valhahalha_Blazor_ServerContextConnection") ?? throw new InvalidOperationException("Connection string 'Valhahalha_Blazor_ServerContextConnection' not found.");

builder.Services.AddDbContext<Valhahalha_Blazor_ServerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<Valhahalha_Blazor_ServerContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "AspNetCore.Cookies";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
        options.SlidingExpiration = true;
    }); 
builder.Services.AddScoped<IRoles, Roles>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

////builder.Services.AddScoped<HttpClient>(s =>
////{
////    return new HttpClient { BaseAddress = new Uri(@"https://localhost:7075/") };
////});

builder.Services.AddHttpClient<IAlbunsServices, AlbumServices>(client =>
{
    client.BaseAddress = new Uri(@"https://localhost:7075/");
    client.DefaultRequestHeaders.Add("Acept", "Application/+json");
});

builder.Services.AddHttpClient<IComentarioServices, ComentarioServices>(client =>
{
    client.BaseAddress = new Uri(@"https://localhost:7075/");
    client.DefaultRequestHeaders.Add("Acept", "Application/+json");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

await CriarPerfilDeUsuarioAsync(app);

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;
app.UseAuthorization();

app.Run();

async Task CriarPerfilDeUsuarioAsync(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using ( var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<IRoles>();
        await service.SeedRolesAsync();
        await service.SeedUserAsync();
    }
}