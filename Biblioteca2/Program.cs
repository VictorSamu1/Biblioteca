// See https://aka.ms/new-console-template for more information
using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;
using Biblioteca.Services;


internal class Program
{


    private static void Main(string[] args)
    {

        var usuarios = new List<Usuario>();
        var livros = new List<Livro>();
        var emprestimos = new List<Emprestimo>();

        var usuarioServices = new UsuarioServices(usuarios);
        var livroServices = new LivroServices(livros);
        var emprestimoServices = new EmprestimoServices(emprestimos, livroServices, usuarioServices);

        Usuario? usuarioLogado = null;

        while (true)
        {
            
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Login");
            Console.WriteLine("3 - Cadastrar Livro");
            Console.WriteLine("4 - Emprestar Livro");
            Console.WriteLine("5 - Devolver Livro");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Senha: ");
                    string senha = Console.ReadLine();

                    var novoUsuario = new Usuario
                    {
                        IdU = usuarios.Count + 1,
                        Nome = nome,
                        Email = email,
                        Senha = senha
                    };

                    usuarioServices.Cadastrar(novoUsuario);
                    Console.WriteLine("Usuário cadastrado com sucesso!");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("Email: ");
                    string emailLogin = Console.ReadLine();

                    Console.Write("Senha: ");
                    string senhaLogin = Console.ReadLine();

                    usuarioLogado = usuarios
                        .FirstOrDefault(u => u.Email == emailLogin && u.Senha == senhaLogin);

                    if (usuarioLogado == null)
                        Console.WriteLine("Usuário ou senha incorretos!");
                    else
                        Console.WriteLine($"Bem-vindo, {usuarioLogado.Nome}!");

                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();

                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();

                    Console.Write("Quantidade: ");
                    int qtd = int.Parse(Console.ReadLine());

                    var novoLivro = new Livro
                    {
                        IdL = livros.Count + 1,
                        Titulo = titulo,
                        Autor = autor,
                        Quantidade = qtd
                    };

                    livroServices.Cadastrar(novoLivro);
                    Console.WriteLine("Livro cadastrado!");
                    Console.ReadKey();
                    break;

                case "4":
                    if (usuarioLogado == null)
                    {
                        Console.WriteLine("Você precisa estar logado!");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("ID do livro para emprestar: ");
                    int idEmp = int.Parse(Console.ReadLine());

                    bool emprestou = emprestimoServices.RegistrarEmprestimo(idEmp, usuarioLogado.IdU);

                    if (emprestou)
                        Console.WriteLine("Livro emprestado!");
                    else
                        Console.WriteLine("Erro: livro indisponível!");

                    Console.ReadKey();
                    break;

                case "5":
                    Console.Write("ID do livro a devolver: ");
                    int idDev = int.Parse(Console.ReadLine());

                    bool devolveu = emprestimoServices.RegistrarDevolucao(idDev);

                    if (devolveu)
                        Console.WriteLine("Livro devolvido!");
                    else
                        Console.WriteLine("Nenhum empréstimo encontrado desse livro!");

                    Console.ReadKey();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    Console.ReadKey();
                    break;

                    
            }
        }
    }
}

