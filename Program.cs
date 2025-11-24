using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
