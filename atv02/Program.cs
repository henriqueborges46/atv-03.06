using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeProdutos
{
    class Produto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public Produto(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"Descrição: {Descricao}, Valor: R${Valor:F2}";
        }
    }

    class Program
    {
        static List<Produto> listaProdutos = new List<Produto>();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                MostrarMenu();
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;
                    case 2:
                        RemoverProduto();
                        break;
                    case 3:
                        PesquisarProduto();
                        break;
                    case 4:
                        MostrarProdutoComMenorValor();
                        break;
                    case 5:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine(); // Linha em branco para separar as ações
            } while (opcao != 5);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("===== Gerenciador de Produtos =====");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Remover produto");
            Console.WriteLine("3 - Pesquisar produto");
            Console.WriteLine("4 - Mostrar produto com menor valor");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        static void CadastrarProduto()
        {
            Console.Write("Informe a descrição do produto: ");
            string descricao = Console.ReadLine();

            Console.Write("Informe o valor do produto: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Produto novoProduto = new Produto(descricao, valor);
                listaProdutos.Add(novoProduto);
                Console.WriteLine("Produto cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Valor inválido. Produto não cadastrado.");
            }
        }

        static void RemoverProduto()
        {
            Console.Write("Informe a descrição do produto a ser removido: ");
            string descricao = Console.ReadLine();

            Produto produtoRemover = listaProdutos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));

            if (produtoRemover != null)
            {
                listaProdutos.Remove(produtoRemover);
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        static void PesquisarProduto()
        {
            Console.Write("Informe a descrição do produto a ser pesquisado: ");
            string descricao = Console.ReadLine();

            Produto produto = listaProdutos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));

            if (produto != null)
            {
                Console.WriteLine("Produto encontrado:");
                Console.WriteLine(produto);
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        static void MostrarProdutoComMenorValor()
        {
            if (listaProdutos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            Produto menorValor = listaProdutos.OrderBy(p => p.Valor).First();
            Console.WriteLine("Produto com menor valor:");
            Console.WriteLine(menorValor);
        }
    }
}
