using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorAlunos
{
    class Program
    {
        static List<Aluno> alunos = new List<Aluno>();
        static void Main(string[] args)
        {
            bool sair = false;
            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("=== Sistemas de Gerenciamento de Alunos ===");
                Console.WriteLine("1.Adicionar Aluno");
                Console.WriteLine("2.RA do aluno");
                Console.WriteLine("3. Idade do Aluno");
                Console.WriteLine("4. Listar Alunos");
                Console.WriteLine("5. Buscar Aluno por Nome");
                Console.WriteLine("6. Remover Aluno");
                Console.WriteLine("7. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarAluno();
                        break;
                    case "2":
                        ListarAlunos();
                        break;
                    case "3":
                        BuscarAluno();
                        break;
                    case "4":
                        RemoverAluno();
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (!sair)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Programa encerrado.");
        }

        static void AdicionarAluno()
        {
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a matrícula: ");
            string matricula = Console.ReadLine();

            alunos.Add(new Aluno { Nome = nome, Matricula = matricula });

            Console.WriteLine("Aluno adicionado com sucesso!");
        }

        static void ListarAlunos()
        {
            Console.WriteLine("=== Lista de Alunos ===");
            if (alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
            }
            else
            {
                foreach (var aluno in alunos)
                {
                    Console.WriteLine($"Nome: {aluno.Nome} | Matrícula: {aluno.Matricula}");
                }
            }
        }

        static void BuscarAluno()
        {
            Console.Write("Digite o nome do aluno para buscar: ");
            string nomeBusca = Console.ReadLine();

            var resultados = alunos.Where(a => a.Nome.ToLower().Contains(nomeBusca.ToLower())).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum aluno encontrado com esse nome.");
            }
            else
            {
                Console.WriteLine("Resultados encontrados:");
                foreach (var aluno in resultados)
                {
                    Console.WriteLine($"Nome: {aluno.Nome} | Matrícula: {aluno.Matricula}");
                }
            }
        }

        static void RemoverAluno()
        {
            Console.Write("Digite o nome do aluno para remover: ");
            string nomeRemover = Console.ReadLine();

            var aluno = alunos.FirstOrDefault(a => a.Nome.Equals(nomeRemover, StringComparison.OrdinalIgnoreCase));

            if (aluno != null)
            {
                alunos.Remove(aluno);
                Console.WriteLine("Aluno removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Aluno não encontrado.");
            }
        }
    }

    class Aluno
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
    }
}
              
