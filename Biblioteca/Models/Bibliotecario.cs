using Biblioteca.Interfaces;
using Biblioteca.Models.Items;

namespace Biblioteca.Models
{
    internal class Bibliotecario : IAutenticavel
    {
        public Bibliotecario(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }
        private string Login { get; set; }
        private string Senha { get; set; }

        public bool Autenticar()
        {
            Console.WriteLine("Digite o login: ");
            string login = Console.ReadLine();

            Console.WriteLine("Digite a senha: ");
            string senha = Console.ReadLine();

            if (login == this.Login && senha == this.Senha)
            {
                Console.WriteLine("Login e senha confirmados");
                return true;
            }
            else
            {
                Console.WriteLine("Login ou senha está incorreto");
                return false;
            }
        }
        public void FazerEmprestimo(Usuario usuario, Livro livroEmprestado)
        {
            if (livroEmprestado.GetDisponivel())
            {
                if (Autenticar())
                {
                    Emprestimo emprestimo = new Emprestimo(usuario, livroEmprestado);
                    if (emprestimo != null)
                    {
                        usuario.UsuarioAddEmprestimo(emprestimo);
                        livroEmprestado.ItemAddEmprestimo(emprestimo);
                    }
                }
                else
                {
                    Console.WriteLine("Falha na Autenticação");
                }
            }
            else
            {
                Console.WriteLine("Livro indisponível...");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
        }
        public void FazerEmprestimo(Usuario usuario, Jornal jornalEmprestado)
        {
            if (jornalEmprestado.GetDisponivel())
            {
                if (Autenticar())
                {
                    Emprestimo emprestimo = new Emprestimo(usuario, jornalEmprestado);
                    if (emprestimo != null)
                    {
                        usuario.UsuarioAddEmprestimo(emprestimo);
                        jornalEmprestado.ItemAddEmprestimo(emprestimo);
                    }
                }
                else
                {
                    Console.WriteLine("Falha na Autenticação");
                }
            }
            else
            {
                Console.WriteLine("Jornal indisponível...");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
        }
    }
}
