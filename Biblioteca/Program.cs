﻿using Biblioteca.Models;
using Biblioteca.Models.Items;

Bibliotecario bibliotecario = new Bibliotecario(login: "123", senha: "123");

Dictionary<string, Livro> livros = Item.DeserializeItemLivro();

Dictionary<string, Jornal> jornais = Item.DeserializeItemJornal();

Dictionary<string, Usuario> usuarios = Usuario.Deserialize();


bool continua = true;

while (continua == true)
{
    switch (Menu.MenuPrincipal())
    {
        case 0://Sair
            Console.WriteLine("Você finalizou o programa, até a próxima...");
            Console.WriteLine("Pressione ENTER para finalizar...");
            continua = false;
            break;

        case 1://Listar livros
            Livro.GetLivros(livros);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 2://Listar Jornais
            Jornal.GetJornais(jornais);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 3://Listar Usuários

            Usuario.GetUsuarios(usuarios, bibliotecario);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 4://Fazer empréstimo de Livro
            Console.WriteLine("Digite o CPF do Usuário sem pontos:");
            string cpf = Console.ReadLine();
            string codigo;

            if (usuarios.ContainsKey(cpf))
            {
                Console.WriteLine("Digite o código do Item a ser emprestado:");
                codigo = Console.ReadLine();

                if (livros.ContainsKey(codigo))
                {
                    bibliotecario.FazerEmprestimo(usuarios[cpf], livros[codigo]);
                }
                else if (jornais.ContainsKey(codigo))
                {
                    bibliotecario.FazerEmprestimo(usuarios[cpf], jornais[codigo]);
                }
                else
                {
                    Console.WriteLine("Item não encontrado... Por favor, confira o código e tente novamente");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Usuário não encontrado... Por favor, confira o código e tente novamente");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
            break;

        case 5://Devolver empréstimo
            Console.WriteLine("Digite o CPF usuário sem pontos:");
            cpf = Console.ReadLine();



            if (usuarios.ContainsKey(cpf))
            {

                Console.WriteLine("Digite o código do empréstimo do usuário:");
                int codigoEmprestimo = int.Parse(Console.ReadLine());

                string codigoItemDevolvido = usuarios[cpf].Devolver(codigoEmprestimo);//FIX

                if (livros.ContainsKey(codigoItemDevolvido))
                    livros[codigoItemDevolvido].setDisponivel();

                else if (jornais.ContainsKey(codigoItemDevolvido))
                    jornais[codigoItemDevolvido].setDisponivel();

                else
                    Console.WriteLine("Código de empréstimo do usuário não encontrado");
            }
            else
                Console.WriteLine("CPF não encontrado...");

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 6://Listar todos empréstimos
            Usuario.GetAllUsuariosEmprestimos(usuarios);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 7://Listar empréstimos de um usuário
            Console.WriteLine("Digite o CPF usuário sem pontos:");
            cpf = Console.ReadLine();
            try
            {
                Emprestimo.GetEmprestimo(usuarios[cpf]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 8://Listar empréstimos de um item
            Console.WriteLine("Digite o código do item: ");
            codigo = Console.ReadLine();
            if (livros.ContainsKey(codigo))
            {
                livros[codigo].GetEmprestimosItem();
            }
            else if (jornais.ContainsKey(codigo))
            {
                jornais[codigo].GetEmprestimosItem();
            }
            else
            {
                Console.WriteLine("Código não encontrado");
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;
        case 9:
            if(bibliotecario.Autenticar())
            Cadastro();
            else
                Console.WriteLine("Você não tem permissão para acessar esse menu");

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("Valor inválido... tente novamente");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;
    }
}

void Cadastro()
{
    switch (Menu.MenuCadastro())
    {
        case 0://Voltar
            Console.WriteLine("Voltando para o menu principal...");
            break;

        case 1://Inserir livro
            Console.Write("Digite o Titulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Digite o Gênero: ");
            string genero = Console.ReadLine();

            string codigo = (livros.Count()+1).ToString() + "L";

            livros.Add(codigo, new Livro(titulo, autor, genero, codigo, DateTime.Now, true));
            Console.WriteLine("Livro cadastrado com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 2://Inserir jornal
            Console.Write("Digite o Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a Editora: ");
            string editora = Console.ReadLine();

            Console.Write("Digite o Numero de edição: ");
            string numeroEdicao = Console.ReadLine();

            Console.Write("Digite o local: ");
            string local = Console.ReadLine();
            Console.Write("Digite a data de publicacao (dia-mes-ano): ");
            string dataPublicacaoString = Console.ReadLine();
            try
            {
                
                DateTime dataPublicacao = Convert.ToDateTime(dataPublicacaoString);

                codigo = (jornais.Count()+1).ToString() + "J";

                jornais.Add(codigo, new Jornal(nome, dataPublicacao, editora, numeroEdicao, local, codigo, DateTime.Now, true));
                Console.WriteLine("Jornal cadastrado com sucesso...");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma exceção... o jornal não foi cadastrado");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }


            break;

        case 3://Inserir Usuário
            Console.Write("Digite o nome: ");
            nome = Console.ReadLine();

            Console.Write("Digite o cpf sem pontos: ");
            string cpf = Console.ReadLine();

            if (usuarios.TryAdd(cpf, new Usuario(nome, cpf)))
            {
                Console.WriteLine("Usuário cadastrado com sucesso...");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Não foi possível cadastrar o usuário...");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
            break;



    }
}
Item.SerializeItem(livros);
Item.SerializeItem(jornais);
Usuario.Serialize(usuarios);