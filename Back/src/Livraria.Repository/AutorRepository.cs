using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Livraria.Domain.model;
using Livraria.Repository.Context;
using Livraria.Repository.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DataContext _context;

        public AutorRepository(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Autor[]> GetAllAutoresAsync()
        {
            IQueryable<Autor> query = _context.Autores
            .Include(x => x.Livros);
            query = query.OrderBy(x => x.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Autor> GetAutorByIdAsync(int id)
        {
            IQueryable<Autor> query = _context.Autores
           .Include(x => x.Livros);
            query = query.OrderBy(x => x.Id).Where(x => x.Id.Equals(id));
            return await query.FirstAsync();
        }

        public async Task<Autor> GetAutorByNameAsync(string name)
        {
            IQueryable<Autor> query = _context.Autores
           .Include(x => x.Livros);
            query = query.OrderBy(x => x.Nome.ToLower().Contains(name.ToLower()));
            return await query.FirstAsync();
        }
    }
}