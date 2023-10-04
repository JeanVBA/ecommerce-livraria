using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.model;
using Livraria.Repository.Contratos;
using Livraria.Service.Contratos;

namespace Livraria.Service
{
    public class LivroService : ILivroService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly ILivroRepository _livroRepository;

        public LivroService(IGeralRepository geralRepository, ILivroRepository livroRepository)
        {
            _geralRepository = geralRepository;
            _livroRepository = livroRepository;
        }

        public async Task<Livro> AddLivros(Livro model)
        {
            try
            {
                _geralRepository.Add<Livro>(model);
                if (await _geralRepository.SaveChangesAsync())
                    return await _livroRepository.GetLivroByIdAsync(model.Id);
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error this save Livro:" + e.Message);
            }
        }
        public async Task<Livro> UpdateLivros(int id, Livro model)
        {
            try
            {
                var livro = await _livroRepository.GetLivroByIdAsync(id);
                if (livro == null) return null;
                model.Id = id;
                _geralRepository.Update(model);
                if (await _geralRepository.SaveChangesAsync())
                    return await _livroRepository.GetLivroByIdAsync(model.Id);
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error this update Livro:" + e.Message);
            }
        }

        public async Task<bool> DeleteLivro(int id)
        {
            try
            {
                var livro = await _livroRepository.GetLivroByIdAsync(id);
                if (livro == null) throw new Exception("Error ao deletar Livro");
                _geralRepository.Delete<Livro>(livro);
                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error ao deletar Livro" + e.Message);
            }
        }


        public async Task<Livro[]> GetAllLivrosAsync()
        {
            try
            {
                var livros = await _livroRepository.GetAllLivrosAsync();
                if (livros == null) return null;
                return livros;
            }
            catch (Exception e)
            {
                throw new Exception("Error getAll Livro:" + e.Message);

            }
        }

        public async Task<Livro[]> GetLivroByGeneroAsync(string genero)
        {
            try
            {
                var livros = await _livroRepository.GetLivroByGeneroAsync(genero);
                if (livros == null) return null;
                return livros;
            }
            catch (Exception e)
            {
                throw new Exception("Error getAllGenero Livro:" + e.Message);

            }
        }

        public async Task<Livro> GetLivroByIdAsync(int id)
        {
            try
            {
                var livro = await _livroRepository.GetLivroByIdAsync(id);
                if (livro == null) return null;
                return livro;
            }
            catch (Exception e)
            {
                throw new Exception("Error getId Livro:" + e.Message);

            }
        }

        public async Task<Livro> GetLivroByNameAsync(string name)
        {
            try
            {
                var livro = await _livroRepository.GetLivroByNameAsync(name);
                if (livro == null) return null;
                return livro;
            }
            catch (Exception e)
            {
                throw new Exception("Error getName Livro:" + e.Message);

            }
        }

    }
}