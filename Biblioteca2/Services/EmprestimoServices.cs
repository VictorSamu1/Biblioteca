using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class EmprestimoServices
    {
        private readonly List<Emprestimo> _emprestimos;
        private readonly LivroServices _livroServices;
        private readonly UsuarioServices _usuarioServices;


        public EmprestimoServices(List<Emprestimo> emprestimos, LivroServices livroServices, UsuarioServices usuarioServices)
        {
            _emprestimos = emprestimos;
            _livroServices = livroServices;
            _usuarioServices = usuarioServices;
        }
        // Aqui o RegistrarEmprestimo vai pegar o livro e o usuario pelo Id, irá verificar se o livro e o usuario existem
        public bool RegistrarEmprestimo(int livroId, int usuarioId)
        {
            var livro = _livroServices.BuscarPorId( livroId );
            var usuario = _usuarioServices.BuscarPorId(usuarioId);

            if( livro == null || usuario == null || livro.Quantidade <= 0 ) 
                return false;

            livro.Quantidade--;

            var emprestimo = new Emprestimo
            {
            LivroId = livroId,
            UsuarioId = usuarioId,
            DataEmprestimo = DateTime.Now

            };

            _emprestimos.Add(emprestimo);
            return true;
        }

        public bool RegistrarDevolucao(int idEmprestimo)
        {
            var emprestimo = _emprestimos.FirstOrDefault(e => e.Id == idEmprestimo);

            if (emprestimo == null)
                return false;

            var livro = _livroServices.BuscarPorId(emprestimo.LivroId);

            // devolução
            livro.Quantidade++;
            emprestimo.DataDevolução = DateTime.Now;

            _emprestimos.Remove(emprestimo);
            return true;
        }
    }
}
