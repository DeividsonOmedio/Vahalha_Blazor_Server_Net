using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Valhahalha_Blazor_Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Valhahalha_Blazor_Server.Service.interfaces;
using Valhahalha_Blazor_Server.Service;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Valhahalha_Blazor_ServerContextConnection") ?? throw new InvalidOperationException("Connection string 'Valhahalha_Blazor_ServerContextConnection' not found.");

builder.Services.AddDbContext<Valhahalha_Blazor_ServerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Valhahalha_Blazor_ServerContext>();



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;
app.UseAuthorization();

app.Run();
