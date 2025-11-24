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

        public void Cadastrar(Projeto Projeto)
        {
            _context.Projetos.Add(Projeto);
            _context.SaveChanges();
        }
        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }
        public void Atualizar(int id, Projeto projeto)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);

            if (projetoBuscado != null)
            {
                projetoBuscado.NomeDoProjeto = projeto.NomeDoProjeto;
                projetoBuscado.Area = projeto.Area;
                projetoBuscado.Status = projeto.Status;

                _context.Projetos.Update(projetoBuscado);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Projeto não encontrado.");
            }
        }
        public void Deletar(int id)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);

            if (projetoBuscado != null)
            {
                _context.Projetos.Remove(projetoBuscado);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Projeto não encontrado.");
            }
        }        

    }
}