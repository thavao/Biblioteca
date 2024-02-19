using Biblioteca.Models;
using Biblioteca.Models.Items;

Bibliotecario bibliotecario = new Bibliotecario(login: "123", senha: "123");

Dictionary<string, Livro> livros = Item.DeserializeItemLivro();

Dictionary<string, Jornal> jornais = Item.DeserializeItemJornal();

Dictionary<string, Usuario> usuarios = Usuario.Deserialize();








int menu()
{
    Console.Clear();
    Console.WriteLine("---- Bem Vindo ao programa Biblioteca ----");
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("[1] - Listar livros \n[2] - Listar Jornais \n[3] - Listar Usuários");
    Console.WriteLine("[4] - Fazer empréstimo de Livro\n[5] - Devolver empréstimo\n[6] - Listar todos empréstimos");
    Console.WriteLine("[7] - Listar empréstimos de um usuário\n[8] - Listar empréstimos de um item\n[0] - Sair");
    Console.WriteLine("------------------------------------------");
    return int.Parse(Console.ReadLine());
}
bool continua = true;

while (continua == true)
{
    switch (menu())
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
            Console.WriteLine("Digite o código do Livro a ser emprestado:");
            string codigo = Console.ReadLine();

            if (usuarios.ContainsKey(codigo))
            {
                if (livros.ContainsKey(codigo))
                {
                    bibliotecario.FazerEmprestimo(usuarios[cpf], livros[codigo]);
                }
                if (jornais.ContainsKey(codigo))
                {
                    bibliotecario.FazerEmprestimo(usuarios[cpf], jornais[codigo]);
                }
                else
                {
                    Console.WriteLine("Item não encontrado... Por favor, confira o código e tente novamente");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }else
            {
                Console.WriteLine("Usuário não encontrado... Por favor, confira o código e tente novamente");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
            break;

        case 5://Devolver empréstimo
            Console.WriteLine("Digite o CPF usuário sem pontos:");
            cpf = Console.ReadLine();

            

            if (usuarios.ContainsKey(cpf)) {

                Console.WriteLine("Digite o código do empréstimo do usuário:");
                int codigoEmprestimo = int.Parse(Console.ReadLine());

                string codigoItemDevolvido = usuarios[cpf].Devolver(codigoEmprestimo);//FIX

                if (livros.ContainsKey(codigoItemDevolvido))
                    livros[codigoItemDevolvido].setDisponivel();

                if (jornais.ContainsKey(codigoItemDevolvido))
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
            if (jornais.ContainsKey(codigo))
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
        default:
            Console.WriteLine("Valor inválido... tente novamente");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;
    }
}

Item.SerializeItem(livros);
Item.SerializeItem(jornais);
Usuario.Serialize(usuarios);