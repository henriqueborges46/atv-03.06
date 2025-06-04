using System;

namespace SistemaDePagamentos
{
    public interface IPagamento
    {
        void ProcessarPagamento(decimal valor);
    }
    public class PagamentoCartaoCredito : IPagamento
    {
        public void ProcessarPagamento(decimal valor)
        {
            Console.WriteLine($"Pagamento de R${valor:F2} processado no cartão de crédito.");
        }
    }
    public class PagamentoBoleto : IPagamento
    {
        public void ProcessarPagamento(decimal valor)
        {
            Console.WriteLine($"Pagamento de R${valor:F2} processado via boleto bancário.");
        }
    }
    public class LojaVirtual
    {
        public void RealizarPagamento(IPagamento metodo, decimal valor)
        {
            metodo.ProcessarPagamento(valor);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LojaVirtual loja = new LojaVirtual();

            IPagamento pagamentoCartao = new PagamentoCartaoCredito();
            IPagamento pagamentoBoleto = new PagamentoBoleto();

            Console.WriteLine("Exemplo com cartão:");
            loja.RealizarPagamento(pagamentoCartao, 150.75m);

            Console.WriteLine("\nExemplo com boleto:");
            loja.RealizarPagamento(pagamentoBoleto, 89.90m);
        }
    }
}

