using System.Net.Http.Json;
using System.Text.Json;

class Program
{
    private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5170/api/") };

    static async Task Main()
    {
        Console.WriteLine("Cliente Console - Loja de Roupas");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Listar Roupas");
            Console.WriteLine("2 - Adicionar Roupa");
            Console.WriteLine("3 - Editar Roupa");
            Console.WriteLine("4 - Excluir Roupa");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": await ListarRoupas(); break;
                case "2": await AdicionarRoupa(); break;
                case "3": await EditarRoupa(); break;
                case "4": await ExcluirRoupa(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida!"); break;
            }
        }
    }

    static async Task ListarRoupas()
    {
        var roupas = await client.GetFromJsonAsync<List<Roupa>>("roupas");
        if (roupas == null || roupas.Count == 0)
        {
            Console.WriteLine("Nenhuma roupa cadastrada.");
            return;
        }

        foreach (var roupa in roupas)
        {
            Console.WriteLine($"ID: {roupa.Id} | Nome: {roupa.Nome} | Tamanho: {roupa.Tamanho} | Preço: {roupa.Preco:C}");
        }
    }

    static async Task AdicionarRoupa()
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine();
        Console.Write("Tamanho: ");
        var tamanho = Console.ReadLine();
        Console.Write("Preço: ");
        var preco = decimal.Parse(Console.ReadLine() ?? "0");

        var novaRoupa = new Roupa { Nome = nome!, Tamanho = tamanho!, Preco = preco };

        var response = await client.PostAsJsonAsync("roupas", novaRoupa);
        Console.WriteLine(response.IsSuccessStatusCode ? "Roupa adicionada!" : "Erro ao adicionar roupa.");
    }

    static async Task EditarRoupa()
    {
        Console.Write("ID da roupa: ");
        var id = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Novo Nome: ");
        var nome = Console.ReadLine();
        Console.Write("Novo Tamanho: ");
        var tamanho = Console.ReadLine();
        Console.Write("Novo Preço: ");
        var preco = decimal.Parse(Console.ReadLine() ?? "0");

        var roupaAtualizada = new Roupa { Id = id, Nome = nome!, Tamanho = tamanho!, Preco = preco };

        var response = await client.PutAsJsonAsync($"roupas/{id}", roupaAtualizada);
        Console.WriteLine(response.IsSuccessStatusCode ? "Roupa atualizada!" : "Erro ao atualizar roupa.");
    }

    static async Task ExcluirRoupa()
    {
        Console.Write("ID da roupa a excluir: ");
        var id = int.Parse(Console.ReadLine() ?? "0");

        var response = await client.DeleteAsync($"roupas/{id}");
        Console.WriteLine(response.IsSuccessStatusCode ? "Roupa excluída!" : "Erro ao excluir roupa.");
    }
}

public class Roupa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tamanho { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}
