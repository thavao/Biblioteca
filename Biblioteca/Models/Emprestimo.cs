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
        public Emprestimo(Usuario prestamista, Livro livroEmprestado)
        {

            Console.WriteLine("Digite a quantidade de dias que o livro ficará emprestado: ");
            DateTime dataDevolucao = DateTime.Now.AddDays(int.Parse(Console.ReadLine()));

            Console.WriteLine("-- Informações do Emprestimo --");
            Console.WriteLine("Nome do Livro: " + livroEmprestado.Titulo);
            Console.WriteLine("Nome do prestamista: " + prestamista.Nome);
            Console.WriteLine($"Data de Emprestimo: {DateTime.Now.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de Devolução: {dataDevolucao.ToString("dd/MM/yyyy")}");

            Console.WriteLine("Confirmar emprestismo ? [S] - sim | [N] - não");
            string confirmar = Console.ReadLine().ToLower();
            if (confirmar == "s")
            {
                Prestamista = prestamista;
                ItemEmprestado = livroEmprestado;
                DataEmprestimo = DateTime.Now;
                DataDevolucao = dataDevolucao;
                Devolvido = false;

                Console.WriteLine("O emprestimo foi concluído...");
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
        public Emprestimo(Usuario prestamista, Jornal jornalEmprestado)
        {

            Console.WriteLine("Digite a quantidade de dias que o jornal ficará emprestado: ");
            DateTime dataDevolucao = DateTime.Now.AddDays(int.Parse(Console.ReadLine()));

            Console.WriteLine("-- Informações do Emprestimo --");
            Console.WriteLine("Nome do Jornal: " + jornalEmprestado.Nome);
            Console.WriteLine("Editora: " + jornalEmprestado.Editora);
            Console.WriteLine("Numero de edição: " + jornalEmprestado.NumeroEdicao);
            Console.WriteLine("Nome do prestamista: " + prestamista.Nome);
            Console.WriteLine($"Data de Emprestimo: {DateTime.Now.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de Devolução: {dataDevolucao.ToString("dd/MM/yyyy")}");

            Console.WriteLine("Confirmar emprestismo ? [S] - sim | [N] - não");
            string confirmar = Console.ReadLine().ToLower();
            if (confirmar == "s")
            {

                Prestamista = prestamista;
                ItemEmprestado = jornalEmprestado;
                DataEmprestimo = DateTime.Now;
                DataDevolucao = dataDevolucao;
                Devolvido = false;

                
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
        public Usuario Prestamista { get; private set; }
        public Item ItemEmprestado { get; private set; }
        public DateTime DataEmprestimo {  get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public bool Devolvido { get; private set; }



        public void Devolver()
        {
            this.Devolvido = true;
            Console.WriteLine("Item devolvido com sucesso!");
        }
        public void GetEmprestimo(int codigoDoEmprestimo)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--Informações do usuário--");
            Console.WriteLine($"CPF do usuário: {Prestamista.GetCPF()}");
            Console.WriteLine($"Nome: {Prestamista.Nome}");
            Console.WriteLine("--Informações do item--");
            Console.WriteLine($"{ItemEmprestado.GetCodigo()}");
            Console.WriteLine($"Data de emprestimo: {DataEmprestimo.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de devolução: {DataDevolucao.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Situação: {(Devolvido ? "devolvido" : "não devolvido")}");
            Console.WriteLine($"Codigo do Emprestimo: {codigoDoEmprestimo}");
            Console.WriteLine("--------------------------------------------");
        }
        public void GetEmprestimo()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--Informações do usuário--");
            Console.WriteLine($"CPF do usuário: {Prestamista.GetCPF()}");
            Console.WriteLine($"Nome: {Prestamista.Nome}");
            Console.WriteLine("--Informações do item--");
            Console.WriteLine($"{ItemEmprestado.GetCodigo()}");
            Console.WriteLine($"{ItemEmprestado.GetCodigo()}");
            Console.WriteLine($"Data de emprestimo: {DataEmprestimo.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de devolução: {DataDevolucao.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Situação: {(Devolvido ? "devolvido" : "não devolvido")}");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
