using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biblioteca.Models.Items
{
    internal class Item
    {
        protected string Codigo { get; set; }
        protected DateTime DataAquisicao { get; set; }
        protected bool Disponivel { get; set; } = true;
        protected List<Emprestimo> Emprestimos { get; set; }

        public Item() { }
        public Item(string codigo, DateTime dataAquisicao)
        {
            Codigo = codigo;
            DataAquisicao = dataAquisicao;
            Emprestimos = new List<Emprestimo>();
        }
        public string GetCodigo()
        {
            return Codigo;
        }
        public void GetEmprestimosItem()
        {
            if (Emprestimos.Count > 0) { 
            foreach (var item in Emprestimos)
            {
                item.GetEmprestimo();
            }
            }else {
                Console.WriteLine("Este livro ainda não foi emprestado...");
            }

        }
        public bool GetDisponivel()
        {
            return Disponivel;
        }
        public void ItemAddEmprestimo(Emprestimo emprestimo)
        {
            Disponivel = false;
            Emprestimos.Add(emprestimo);
        }
    }
}
