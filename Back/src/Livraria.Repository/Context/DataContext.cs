using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.model;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editora> Editoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().HasOne(x => x.Autor).WithMany(x => x.Livros);
            modelBuilder.Entity<Livro>().HasOne(x => x.Editora).WithMany(x => x.Acervo);
        }
    }
}