using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Domain.model
{
    public class Editora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Livro> Acervo { get; set; }
    }
}