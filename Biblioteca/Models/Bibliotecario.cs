using Biblioteca.Interfaces;
using Biblioteca.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (Autenticar())
            {
                Emprestimo emprestimo = new Emprestimo(usuario, livroEmprestado);
                usuario.UsuarioAddEmprestimo(emprestimo);
                livroEmprestado.LivroAddEmprestimo(emprestimo);
            }
            else
            {
                Console.WriteLine("Falha na Autenticação");
            }
        }
        public void FazerEmprestimo(Usuario usuario, Jornal JornalEmprestado)
        {

            if (Autenticar())
            {
                Emprestimo emprestimo = new Emprestimo(usuario, JornalEmprestado);
                usuario.UsuarioAddEmprestimo(emprestimo);
                JornalEmprestado.JornalAddEmprestimo(emprestimo);
            }
            else
            {
                Console.WriteLine("Falha na Autenticação");
            }
        }
    }
}
