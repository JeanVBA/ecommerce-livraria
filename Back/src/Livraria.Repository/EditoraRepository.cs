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
    public class EditoraRepository : IEditoraRepository
    {
        private readonly DataContext _context;

        public EditoraRepository(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Editora[]> GetAllEditorasAsync()
        {
            IQueryable<Editora> query = _context.Editoras
            .Include(x => x.Acervo);
            query = query.OrderBy(x => x.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Editora> GetEditoraByIdAsync(int id)
        {
            IQueryable<Editora> query = _context.Editoras
           .Include(x => x.Acervo);
            query = query.OrderBy(x => x.Id).Where(x => x.Id.Equals(id));
            return await query.FirstAsync();
        }

        public async Task<Editora> GetEditoraByNameAsync(string name)
        {
            IQueryable<Editora> query = _context.Editoras
           .Include(x => x.Acervo);
            query = query.OrderBy(x => x.Nome.ToLower().Contains(name.ToLower()));
            return await query.FirstAsync();
        }
    }
}