using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Models.Items;

namespace Biblioteca.Models
{
    internal class Emprestimo
    {
        public Emprestimo() { }
        public Emprestimo(Usuario usuario, Livro livroEmprestado)
        {
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine("Digite a quantidade de dias que o livro ficará emprestado: ");
            DateTime dataDevolucao = DateTime.Now.AddDays(int.Parse(Console.ReadLine()));

            Console.WriteLine("-- Informações do Empréstimo --");
            Console.WriteLine("Nome do Livro: " + livroEmprestado.Titulo);
            Console.WriteLine("Nome do prestamista: " + usuario.Nome);
            Console.WriteLine($"Data de empréstimo: {DateTime.Now.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de Devolução: {dataDevolucao.ToString("dd/MM/yyyy")}");

            Console.WriteLine("Confirmar empréstimo ? [S] - sim | [N] - não");
            string confirmar = Console.ReadLine().ToLower();
            if (confirmar == "s")
            {

                DataEmprestimo = DateTime.Now;
                DataDevolucao = dataDevolucao;
                Devolvido = false;
                CPFUsuario = usuario.GetCPF();
                CodigoItem = livroEmprestado.Codigo;

                Console.WriteLine("O empréstimo foi concluído...");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("O empréstimo não foi concluído...");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
            }
        }
        public Emprestimo(Usuario usuario, Jornal jornalEmprestado)
        {
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine("Digite a quantidade de dias que o jornal ficará emprestado: ");
            DateTime dataDevolucao = DateTime.Now.AddDays(int.Parse(Console.ReadLine()));

            Console.WriteLine("-- Informações do empréstimo --");
            Console.WriteLine("Nome do Jornal: " + jornalEmprestado.Nome);
            Console.WriteLine("Editora: " + jornalEmprestado.Editora);
            Console.WriteLine("Numero de edição: " + jornalEmprestado.NumeroEdicao);
            Console.WriteLine("Nome do prestamista: " + usuario.Nome);
            Console.WriteLine($"Data de empréstimo: {DateTime.Now.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de Devolução: {dataDevolucao.ToString("dd/MM/yyyy")}");

            Console.WriteLine("Confirmar empréstimo ? [S] - sim | [N] - não");
            string confirmar = Console.ReadLine().ToLower();
            if (confirmar == "s")
            {

                DataEmprestimo = DateTime.Now;
                DataDevolucao = dataDevolucao;
                Devolvido = false;
                CPFUsuario = usuario.GetCPF();
                CodigoItem = jornalEmprestado.Codigo;

                Console.WriteLine("O empréstimo foi concluído...");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("O emprestimo não foi concluído...");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
            }

        }
        public DateTime DataEmprestimo { get; private set; }
        public string CodigoItem { get; set; }
        public string CPFUsuario { get; set; }
        public DateTime DataDevolucao { get; private set; }
        public bool Devolvido { get; private set; }

        public bool Devolver()
        {
            Console.WriteLine("Item devolvido com sucesso!");

            return Devolvido = true;
            
        }
        public static void GetEmprestimo(Usuario usuario)
        {
            int i = 0;
            if (usuario.Emprestimos.Count > 0)
            {
                foreach (var emprestimo in usuario.Emprestimos)
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("--Informações do usuário--");
                    Console.WriteLine($"CPF do usuário: {usuario.GetCPF(): 000.000.000-00}");
                    Console.WriteLine($"Nome: {usuario.Nome}");
                    Console.WriteLine("--Informações do item--");
                    Console.WriteLine($"Código do Item: {emprestimo.CodigoItem}");
                    Console.WriteLine($"Data de emprestimo: {emprestimo.DataEmprestimo.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Data de devolução: {emprestimo.DataDevolucao.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Situação: {(emprestimo.Devolvido ? "devolvido" : "não devolvido")}");
                    Console.WriteLine($"Codigo do Emprestimo: {i}");
                    Console.WriteLine("--------------------------------------------");
                    i++;
                }
            }
            else
            {
                Console.WriteLine($"{usuario.Nome}, {usuario.GetCPF(): 000.000.000-00} ainda não possui empréstimos na biblioteca");
            }
        }
       public void GetEmprestimo()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--Informações do usuário--");
            Console.WriteLine($"CPF do usuário: {CPFUsuario:000.000.000-00}");
            
            Console.WriteLine("--Informações do item--");
            Console.WriteLine($"Código do Item: {CodigoItem}");
            Console.WriteLine($"Data de empréstimo: {DataEmprestimo.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de devolução: {DataDevolucao.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Situação: {(Devolvido ? "devolvido" : "não devolvido")}");
            Console.WriteLine("--------------------------------------------");
        }
        
    }
}
