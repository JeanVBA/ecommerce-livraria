using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.model;

namespace Livraria.Repository.Contratos
{
    public interface IEditoraRepository
    {
        Task<Editora[]> GetAllEditorasAsync();
        Task<Editora> GetEditoraByIdAsync(int id);
        Task<Editora> GetEditoraByNameAsync(string name);
    }
}