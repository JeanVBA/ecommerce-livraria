using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Domain.model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string UrlImage { get; set; }
        public Autor Autor { get; set; }
        public Editora Editora { get; set; }
    }
}