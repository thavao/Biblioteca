namespace Biblioteca.Models.Items
{
    internal class Jornal : Item
    {
        

        public Jornal(string nome, DateTime dataPublicacao, string editora, string numeroEdicao, string local, string codigo, DateTime dataAquisicao) : base(codigo, dataAquisicao)
        {
            Nome = nome;
            Editora = editora;
            DataPublicacao = dataPublicacao;
            NumeroEdicao = numeroEdicao;
            Local = local;
        }

        public string Nome { get; private set; }
        public string Editora { get; private set; }

        public string NumeroEdicao { get; private set; }

        public string Local { get; private set; }
        public DateTime DataPublicacao { get; private set; }
        
        public static void GetJornais(Dictionary<string, Jornal> jornais)
        {
            foreach (var jornal in jornais)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Código: {jornal.Key}");
                Console.WriteLine($"Nome: {jornal.Value.Nome}");
                Console.WriteLine($"Data de Publicação: {jornal.Value.DataPublicacao}");
                Console.WriteLine($"Editora: {jornal.Value.Editora}");
                Console.WriteLine($"Número da Edição: {jornal.Value.NumeroEdicao}");
                Console.WriteLine($"Local: {jornal.Value.Local}");
                Console.WriteLine($"Situação: {(jornal.Value.Disponivel ? "disponível" : "indisponível")}");
                Console.WriteLine($"Data de Aquisição: {jornal.Value.DataAquisicao}");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
            }
        }

    }
}
