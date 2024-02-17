﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models.Items
{
    internal class Livro : Item
    {
        public Livro()
        {

        }
        public Livro(string titulo, string autor, string genero, string codigo, DateTime dataAquisicao) : base(codigo, dataAquisicao)
        {
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
        }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Genero { get; private set; }

        public void LivroAddEmprestimo(Emprestimo emprestimo)
        {
            Emprestimos.Add(emprestimo);
        }
        public void GetLivros(Dictionary<string, Livro> livros)
        {
            foreach (var livro in livros)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Código: {livro.Key}");
                Console.WriteLine($"Título: {livro.Value.Titulo}");
                Console.WriteLine($"Autor: {livro.Value.Autor}");
                Console.WriteLine($"Gênero: {livro.Value.Genero}");
                Console.WriteLine($"Data de Aquisição: {livro.Value.DataAquisicao.ToString("dd/MM/yyyy")}");
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
        }
        public string GetCodigo(Livro livro)
        {
            return livro.Codigo;
        }

    }
}