using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;



namespace Biblioteca.Services
{
    public class LivroServices
    {
        private readonly List<Livro> _livros;

        public LivroServices(List<Livro> livros)
        {
            _livros = livros;
        }

        public void Cadastrar(Livro livro)
        {
            _livros.Add(livro);
        }

        public IEnumerable<Livro> ListarDisponiveis()
        {
            return _livros.Where(l => l.Disponivel);
        }

        public Livro? BuscarPorId(int id)
        {
            return _livros.FirstOrDefault(l => l.IdL == id);
        }
    }
}