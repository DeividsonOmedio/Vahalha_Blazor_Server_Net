using Microsoft.EntityFrameworkCore;
using Valhahalha_Blazor_Server.Api.Context;
using Valhahalha_Blazor_Server.Api.Repository.Interfaces;
using Valhahalha_Blazor_Server.Api.Repository.Services;





// Add services to the container.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao") ?? throw new InvalidOperationException("Connection string 'Valhahalha_Blazor_ServerContextConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAlbum, AlbunsService>();
builder.Services.AddScoped<IComentarios, ComentarioService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
