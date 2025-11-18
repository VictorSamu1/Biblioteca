using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;


namespace Biblioteca.Services
{
    public class UsuarioServices
    {
        private readonly List<Usuario> _usuarios;

        public Usuario? Login(string email, string senha)
        {
            return _usuarios.FirstOrDefault(u =>
                u.Email == email && u.Senha == senha);
        }

        public UsuarioServices(List<Usuario> usuarios)
        {
            _usuarios = usuarios;
        }

        public void Cadastrar(Usuario usuario)
        {

            _usuarios.Add(usuario);
        }

        public Usuario? BuscarPorId(int id)
        {

            return _usuarios.FirstOrDefault(u => u.IdU == id);
        }

        public List<Usuario> ListarUsuarios()
        {

            return _usuarios;


        }
    }
}
      
