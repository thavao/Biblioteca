using Newtonsoft.Json;

namespace Biblioteca.Models.Items
{
    abstract class Item
    {
        public Item(string codigo, DateTime dataAquisicao)
        {
            Codigo = codigo;
            DataAquisicao = dataAquisicao;
            Emprestimos = new List<Emprestimo>();
        }
        public string Codigo { get; protected set; }
        public DateTime DataAquisicao { get; protected set; }
        public bool Disponivel { get;protected set; } =  true;
        public  List<Emprestimo> Emprestimos { get; protected set; }

        public void setDisponivel()
        {
            Disponivel = true;
        }
        public void setIndisponivel()
        {
            Disponivel = false;
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

        public static void SerializeItem(Dictionary<string, Livro> livros)
        {
          
            string caminho = "Arquivos\\Livro.json";
            string jsonString = JsonConvert.SerializeObject(livros, Formatting.Indented);
            File.WriteAllText(caminho, jsonString);
        }
        public static Dictionary<string, Livro> DeserializeItemLivro()
        {
            Dictionary<string, Livro> livros = new Dictionary<string, Livro>();
            string caminho = "Arquivos\\Livro.json";
            
            string jsonString = File.ReadAllText(caminho);

            return livros = JsonConvert.DeserializeObject<Dictionary<string, Livro>>(jsonString);
        }

        public static void SerializeItem(Dictionary<string, Jornal> jornais)
        {

            string caminho = "Arquivos\\Jornal.json";
            string jsonString = JsonConvert.SerializeObject(jornais, Formatting.Indented);
            File.WriteAllText(caminho, jsonString);
        }
        public static Dictionary<string, Jornal> DeserializeItemJornal()
        {
            Dictionary<string, Jornal> jornais = new Dictionary<string, Jornal>();
            string caminho = "Arquivos\\Jornal.json";

            string jsonString = File.ReadAllText(caminho);

            return jornais = JsonConvert.DeserializeObject<Dictionary<string, Jornal>>(jsonString);
        }

    }
}
