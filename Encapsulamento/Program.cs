
using System;
using Encapsulamento.Models;

namespace Encapsulamento
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta = new ContaBancaria(100); 
            string opcao = "";

            Console.WriteLine("=== API Simples de Conta Bancária (Encapsulamento com Propriedades) ===");

            while (opcao != "4")
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Ver Saldo");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Sair");
                Console.Write("Opção: ");
                opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine($"Saldo atual: {conta.Saldo:C}");
                        break;
                    case "2":
                        Console.Write("Digite o valor do depósito: ");
                        decimal valorDep = Convert.ToDecimal(Console.ReadLine());
                        conta.Depositar(valorDep);
                        break;
                    case "3":
                        Console.Write("Digite o valor do saque: ");
                        decimal valorSaq = Convert.ToDecimal(Console.ReadLine());
                        conta.Sacar(valorSaq);
                        break;
                    case "4":
                        Console.WriteLine("Saindo... Até logo!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}

