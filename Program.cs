using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;
// Usings relacionados a JWT que foram removidos:
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Configuração dos Serviços (DI Container) ---

// Registra o DbContext no contêiner de DI. 
// A string de conexão será lida do método OnConfiguring() no ExoContext.cs
builder.Services.AddScoped<ExoContext>(); 

// Registra o repositório
builder.Services.AddTransient<ProjetoRepository>(); 

builder.Services.AddControllers();

var app = builder.Build();

// --- 2. Configuração do Pipeline HTTP ---

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Middlewares de Autenticação/Autorização removidos, pois não são mais necessários
// app.UseAuthentication(); 
app.UseAuthorization(); // Pode ser mantido, mas não fará nada sem Authentication configurado

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
