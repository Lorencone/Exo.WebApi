using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Exo.WebApi.Contexts
{
    public class ExoContext : DbContext
    {
        // Construtor vazio ou mantendo o construtor com opções.
        public ExoContext() { } 

        public ExoContext(DbContextOptions<ExoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var connectionString = "Data Source=Monstro\\SQLEXPRESS;" +
                "Initial Catalog=ExoApi;User ID=sa;Password=3013/k99;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        } 
        public DbSet<Projeto> Projetos { get; set; }  
    }
}