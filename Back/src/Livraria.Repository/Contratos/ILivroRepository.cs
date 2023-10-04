using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.model;

namespace Livraria.Repository.Contratos
{
    public interface ILivroRepository
    {
        Task<Livro[]> GetAllLivrosAsync();
        Task<Livro> GetLivroByIdAsync(int id);
        Task<Livro> GetLivroByNameAsync(string name);
        Task<Livro[]> GetLivroByGeneroAsync(string genero);
    }
}