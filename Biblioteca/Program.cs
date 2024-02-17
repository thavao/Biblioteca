using Biblioteca.Models;
using Biblioteca.Models.Items;
using System.Collections.Generic;

Bibliotecario bibliotecario = new Bibliotecario(login: "123", senha: "123");


#region populando livros
Dictionary<string, Livro> livros = new Dictionary<string, Livro>();

// Adicionando os livros ao dicionário
livros.Add("001L", new Livro("Dom Casmurro", "Machado de Assis", "Romance", "001", new DateTime(1889, 1, 1)));
livros.Add("002L", new Livro("A Arte da Guerra", "Sun Tzu", "Filosofia/Militar", "002", new DateTime(500, 1, 1)));
livros.Add("003L", new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "Fantasia", "003", new DateTime(1954, 7, 29)));
livros.Add("004L", new Livro("O Pequeno Príncipe", "Antoine de Saint-Exupéry", "Fábula", "004", new DateTime(1943, 4, 6)));
livros.Add("005L", new Livro("1984", "George Orwell", "Ficção Científica", "005", new DateTime(1949, 6, 8)));
livros.Add("006L", new Livro("Orgulho e Preconceito", "Jane Austen", "Romance", "006", new DateTime(1813, 1, 28)));
livros.Add("007L", new Livro("Crime e Castigo", "Fiódor Dostoiévski", "Romance", "007", new DateTime(1866, 1, 1)));
livros.Add("008L", new Livro("A Revolução dos Bichos", "George Orwell", "Alegoria", "008", new DateTime(1945, 8, 17)));
livros.Add("009L", new Livro("O Diário de Anne Frank", "Anne Frank", "Biografia/Diário", "009", new DateTime(1947, 6, 25)));
livros.Add("010L", new Livro("Harry Potter e a Pedra Filosofal", "J.K. Rowling", "Fantasia", "010", new DateTime(1997, 6, 26)));
#endregion

#region populando jornais
Dictionary<string, Jornal> jornais = new Dictionary<string, Jornal>();

// Adicionando os jornais ao dicionário
jornais.Add("001J", new Jornal("The New York Times", new DateTime(2024, 2, 16), "NYT Company", "Edição 1", "Nova York", "001", new DateTime(2024, 2, 16)));
jornais.Add("002J", new Jornal("The Guardian", new DateTime(2024, 2, 16), "Guardian News & Media", "Edição 1", "Londres", "002", new DateTime(2024, 2, 16)));
jornais.Add("003J", new Jornal("Le Monde", new DateTime(2024, 2, 16), "Groupe Le Monde", "Edição 1", "Paris", "003", new DateTime(2024, 2, 16)));
jornais.Add("004J", new Jornal("Der Spiegel", new DateTime(2024, 2, 16), "Spiegel-Verlag", "Edição 1", "Hamburgo", "004", new DateTime(2024, 2, 16)));
jornais.Add("005J", new Jornal("El País", new DateTime(2024, 2, 16), "Promotora de Informaciones S.A.", "Edición 1", "Madri", "005", new DateTime(2024, 2, 16)));
jornais.Add("006J", new Jornal("Corriere della Sera", new DateTime(2024, 2, 16), "RCS MediaGroup", "Edizione 1", "Milão", "006", new DateTime(2024, 2, 16)));
jornais.Add("007J", new Jornal("Asahi Shimbun", new DateTime(2024, 2, 16), "The Asahi Shimbun Company", "第1版", "Tóquio", "007", new DateTime(2024, 2, 16)));
jornais.Add("008J", new Jornal("China Daily", new DateTime(2024, 2, 16), "China Daily Group", "第一版", "Pequim", "008", new DateTime(2024, 2, 16)));
jornais.Add("009J", new Jornal("The Times of India", new DateTime(2024, 2, 16), "The Times Group", "Edition 1", "Mumbai", "009", new DateTime(2024, 2, 16)));
jornais.Add("010J", new Jornal("Folha de S.Paulo", new DateTime(2024, 2, 16), "Grupo Folha", "Edição 1", "São Paulo", "010", new DateTime(2024, 2, 16)));
#endregion

#region Populando usuarios
Dictionary<string, Usuario> usuarios = new Dictionary<string, Usuario>();

// Adicionando os usuários ao dicionário
usuarios.Add("12345678901", new Usuario("João da Silva", "123.456.789-01"));
usuarios.Add("23456789012", new Usuario("Maria Oliveira", "234.567.890-12"));
usuarios.Add("34567890123", new Usuario("José Santos", "345.678.901-23"));
usuarios.Add("45678901234", new Usuario("Ana Pereira", "456.789.012-34"));
usuarios.Add("56789012345", new Usuario("Pedro Souza", "567.890.123-45"));
usuarios.Add("67890123456", new Usuario("Carla Costa", "678.901.234-56"));
usuarios.Add("78901234567", new Usuario("Marcos Lima", "789.012.345-67"));
usuarios.Add("89012345678", new Usuario("Aline Martins", "890.123.456-78"));
usuarios.Add("90123456789", new Usuario("Lucas Ferreira", "901.234.567-89"));
usuarios.Add("01234567890", new Usuario("Fernanda Rodrigues", "012.345.678-90"));
#endregion



int menu()
{
    Console.Clear();
    Console.WriteLine("---- Bem Vindo ao programa Biblioteca ----");
    Console.WriteLine("Digite um dos valores e escolha sua ação");
    Console.WriteLine("[1] - Listar livros \n[2] - Listar Jornais \n[3] - Listar Usuários");
    Console.WriteLine("[4] - Fazer empréstimo de Livro \n[5] - Fazer empréstimo de Jornal\n[6] - Devolver empréstimo");
    Console.WriteLine("[7] - Listar todos empréstimos\n[8] - Listar empréstimos de um usuário\n[9] - Listar empréstimos de um item");
    Console.WriteLine("[0] - Sair");
    return int.Parse(Console.ReadLine());
}
bool continua = true;

while (continua == true)
{
    switch (menu())
    {
        case 0:
            Console.WriteLine("Você finalizou o programa, até a próxima...");
            Console.WriteLine("Pressione ENTER para finalizar...");
            continua = false;
            break;

        case 1:
            new Livro().GetLivros(livros);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 2:
            new Jornal().GetJornais(jornais);
            break;

        case 3:
            new Usuario().GetUsuarios(usuarios, bibliotecario);
            break;

        case 4:
            Console.WriteLine("Digite o CPF do Usuário sem pontos:");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite o código do Livro a ser emprestado:");
            string codigo = Console.ReadLine();
            bibliotecario.FazerEmprestimo(usuarios[cpf], livros[codigo]);
            break;

        case 5:
            Console.WriteLine("Digite o CPF do Usuário sem pontos:");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite o código do Jornal a ser emprestado:");
            codigo = Console.ReadLine();
            bibliotecario.FazerEmprestimo(usuarios[cpf], jornais[codigo]);
            break;

        case 6:
            Console.WriteLine("Digite o CPF usuário sem pontos:");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite o código do empréstimo do usuário:");
            int codigoEmprestimo = int.Parse(Console.ReadLine());
            usuarios[cpf].Devolver(codigoEmprestimo);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 7:
            new Usuario().GetAllUsuariosEmprestimos(usuarios);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;

        case 8:
            Console.WriteLine("Digite o CPF usuário sem pontos:");
            cpf = Console.ReadLine();
            usuarios[cpf].GetEmprestimos();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break; 
        case 9:
            Console.WriteLine("Digite o código do item: ");
            codigo = Console.ReadLine();
            livros[codigo].GetEmprestimosItem();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            break;
    }
}