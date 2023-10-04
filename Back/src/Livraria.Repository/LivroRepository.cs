using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.model;
using Livraria.Repository.Context;
using Livraria.Repository.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _context;

        public LivroRepository(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Livro[]> GetAllLivrosAsync()
        {
            IQueryable<Livro> query = _context.Livros
            .Include(x => x.Autor)
            .Include(x => x.Editora);
            query = query.OrderBy(x => x.Id);
            return await query.ToArrayAsync();

        }
        public async Task<Livro> GetLivroByIdAsync(int id)
        {
            IQueryable<Livro> query = _context.Livros
            .Include(x => x.Autor)
            .Include(x => x.Editora);
            query = query.OrderBy(x => x.Id).Where(x => x.Id.Equals(id));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Livro> GetLivroByNameAsync(string name)
        {
            IQueryable<Livro> query = _context.Livros
            .Include(x => x.Autor)
            .Include(x => x.Editora);
            query = query.OrderBy(x => x.Id).Where(x => x.Nome.ToLower().Contains(name.ToLower()));
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Livro[]> GetLivroByGeneroAsync(string genero)
        {
            IQueryable<Livro> query = _context.Livros
            .Include(x => x.Autor)
            .Include(x => x.Editora);
            query = query.OrderBy(x => x.Id).Where(x => x.Genero.ToLower().Equals(genero.ToLower()));
            return await query.ToArrayAsync();
        }

    }
}