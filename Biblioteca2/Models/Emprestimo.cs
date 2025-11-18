using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
        public DateTime? DataDevolução { get; set; }
        public int? UsuarioId { get; set; } 
    }
}
