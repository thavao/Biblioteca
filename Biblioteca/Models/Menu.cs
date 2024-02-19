namespace Biblioteca.Models
{
    internal class Menu
    {
        public static int MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("---- Bem Vindo ao programa Biblioteca ----");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("[1] - Listar livros \n[2] - Listar Jornais \n[3] - Listar Usuários");
            Console.WriteLine("[4] - Fazer empréstimo\n[5] - Devolver empréstimo\n[6] - Listar todos empréstimos");
            Console.WriteLine("[7] - Listar empréstimos de um usuário\n[8] - Listar empréstimos de um item\n[9] - Menu Cadastro");
            Console.WriteLine("[0] - Sair");
            Console.WriteLine("------------------------------------------");
            return int.Parse(Console.ReadLine());
        }
        public static int MenuCadastro()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("[1] - Inserir livro \n[2] - Inserir Jornal \n[3] - Inserir Usuário");
            Console.WriteLine("[0] - Voltar");
            return int.Parse(Console.ReadLine());

        }
    }
}
