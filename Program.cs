using System;

class Program
{
    static void Main()
    {
        int numero1 = 0;
        int numero2 = 0;
        bool sucesso = false;

        while (!sucesso)
        {
            try
            {
                Console.Write("Digite o primeiro número: ");
                numero1 = int.Parse(Console.ReadLine());

                Console.Write("Digite o segundo número: ");
                numero2 = int.Parse(Console.ReadLine());

                int resultado = numero1 / numero2;

                Console.WriteLine($"Resultado: {resultado}");
                sucesso = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Valor inválido. Digite um número inteiro.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Erro: Não é possível dividir por zero.");
            }
        }
    }
}
