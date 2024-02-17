using Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    internal class Usuario
    {
        public Usuario() { }
        public Usuario(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
            Emprestimos = new List<Emprestimo>();
        }
        public string Nome { get; private set; }
        private string CPF { get; set; }
        private List<Emprestimo> Emprestimos { get; set; }

        public int TotalDeEmprestimos { get; set; }


        public void UsuarioAddEmprestimo(Emprestimo emprestimo)
        {
            this.Emprestimos.Add(emprestimo);
        }
        public void GetUsuarios(Dictionary<string, Usuario> usuarios, Bibliotecario bibliotecario)
        {
            if (bibliotecario.Autenticar() == true)
            {

            }
            foreach (var usuario in usuarios)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"CPF: {usuario.Key}");
                Console.WriteLine($"Nome: {usuario.Value.Nome}");
                Console.WriteLine($"CPF Formatado: {usuario.Value.CPF}");
                Console.WriteLine("-------------------------------------------------");
            }
        }
        public void GetEmprestimos()
        {
            int i = 0;
            if(Emprestimos.Count > 0) { 
            foreach (var item in Emprestimos)
            {
                item.GetEmprestimo(i);
                i++;
            }
            }
            else
            {
                Console.WriteLine($"{Nome}, {CPF} ainda não possui empréstimos na biblioteca");
            }
        }
        public void GetAllUsuariosEmprestimos(Dictionary<string, Usuario> usuarios)
        {
            int i = 0;
            foreach (var usuario in usuarios)
            {
                if (Emprestimos != null)
                {
                    i = 0;
                    foreach (var item in Emprestimos)
                    {
                        item.GetEmprestimo(i);
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine($"{usuario.Value.Nome}, {usuario.Value.CPF} ainda não possui empréstimos na biblioteca");
                }
            }
            
        }
        public void Devolver(int codigo)
        {
            Emprestimos[codigo].Devolver();
        }
        public string GetCPF()
        {
            return CPF;
        }

    }
}
