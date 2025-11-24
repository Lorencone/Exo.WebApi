using Exo.WebApi.Models;
using Exo.WebApi.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }
        
        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

    }
}