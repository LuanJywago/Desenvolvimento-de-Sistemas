using System;
namespace Encapsulamento.Models
{
    public class ContaBancaria
    {
        // Propriedade com encapsulamento:
        // Pública para leitura, privada para alteração
        public decimal Saldo { get; private set; }

        public ContaBancaria(decimal saldoInicial)
        {
            Saldo = saldoInicial;
        }

        // Depositar
        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"Depósito de {valor:C} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Valor de depósito inválido!");
            }
        }

        // Sacar
        public void Sacar(decimal valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente ou valor inválido!");
            }
        }
    }
}
