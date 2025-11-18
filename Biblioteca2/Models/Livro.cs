using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int IdL { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public bool Disponivel => Quantidade > 0;
    }
 
    }

