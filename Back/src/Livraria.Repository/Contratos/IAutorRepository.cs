using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.model;

namespace Livraria.Repository.Contratos
{
    public interface IAutorRepository
    {
        Task<Autor[]> GetAllAutoresAsync();
        Task<Autor> GetAutorByIdAsync(int id);
        Task<Autor> GetAutorByNameAsync(string name);
    }
}