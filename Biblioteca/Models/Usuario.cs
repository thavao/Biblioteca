using Newtonsoft.Json;

namespace Biblioteca.Models
{
    internal class Usuario
    {
        public Usuario(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
            Emprestimos = new List<Emprestimo>();
        }
        public string Nome { get; private set; }
        public string CPF { get;  private set; }
        public List<Emprestimo> Emprestimos { get; private set; } = new List<Emprestimo>();



        public void UsuarioAddEmprestimo(Emprestimo emprestimo)
        {
            Emprestimos.Add(emprestimo);
        }
        public static void GetUsuarios(Dictionary<string, Usuario> usuarios, Bibliotecario bibliotecario)
        {
            if (bibliotecario.Autenticar() == true)
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine($"Nome: {usuario.Value.Nome}");
                    Console.WriteLine($"CPF: {usuario.Value.CPF: 000.000.000-00}");
                    Console.WriteLine("-------------------------------------------------");
                }
            }

        }

        public static void GetAllUsuariosEmprestimos(Dictionary<string, Usuario> usuarios)
        {
            int i = 0;
            foreach (var usuario in usuarios)
            {
                if (usuario.Value.Emprestimos.Count != 0)
                {
                    Emprestimo.GetEmprestimo(usuario.Value);
                }
                else
                {
                    Console.WriteLine($"{usuario.Value.Nome}, {usuario.Value.CPF: 000.000.000-00} ainda não possui empréstimos na biblioteca");
                }
            }

        }
        public string Devolver(int codigo)
        {
            try { 
                Emprestimos[codigo].Devolver();
                return Emprestimos[codigo].CodigoItem;
            }catch(ArgumentOutOfRangeException ex )
            {
                Console.WriteLine("Ocorreu uma exceção...");
                Console.WriteLine("Código de empréstimo do usuário não encontrado...");
                Console.WriteLine("Mensagem da exceção: "+ ex.Message);
            }catch(Exception ex)
            {
                Console.WriteLine("Ocorreu uma exceção...");
                Console.WriteLine("Mensagem da exceção: " + ex.Message);
            }
                return "";
            

        }
        public string GetCPF()
        {
            return CPF;
        }

        public static void Serialize(Dictionary<string, Usuario> usuario)
        {
            string caminho = "Arquivos\\Usuario.json";

            string jsonString = JsonConvert.SerializeObject(usuario, Formatting.Indented);
            try
            {
                File.WriteAllText(caminho, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma exceção...");
                Console.WriteLine(ex.Message);
            }
        }

        public static Dictionary<string, Usuario> Deserialize()
        {

            Dictionary<string, Usuario> usuarios = new Dictionary<string, Usuario>();
            string caminho = "Arquivos\\Usuario.json";
            try
            {
                string jsonString = File.ReadAllText(caminho);

                return usuarios = JsonConvert.DeserializeObject<Dictionary<string, Usuario>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma exceção...");
                Console.WriteLine(ex.Message);
                return usuarios;
            }
        }

    }
}
