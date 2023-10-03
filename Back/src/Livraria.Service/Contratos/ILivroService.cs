using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.model;

namespace Livraria.Service.Contratos
{
    public interface ILivroService
    {
        Task<Livro> AddLivros(Livro model);
        Task<Livro> UpdateLivros(int id, Livro model);
        Task<bool> DeleteLivro(int id);

        Task<Livro[]> GetAllLivrosAsync();
        Task<Livro> GetLivroByIdAsync(int id);
        Task<Livro> GetLivroByNameAsync(string name);
        Task<Livro[]> GetLivroByGeneroAsync(Genero genero);
    }
}