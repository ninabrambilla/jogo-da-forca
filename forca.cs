using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] palavras = { "programacao", "computador", "internet", "desenvolvedor", "software" };
        Random rand = new Random();
        string palavra = palavras[rand.Next(palavras.Length)];
        char[] letrasDescobertas = new string('_', palavra.Length).ToCharArray();
        HashSet<char> letrasTentadas = new HashSet<char>();
        int tentativasRestantes = 6;

        Console.WriteLine("Bem-vindo ao Jogo da Forca!");

        while (tentativasRestantes > 0 && new string(letrasDescobertas) != palavra)
        {
            Console.WriteLine($"\nPalavra: {new string(letrasDescobertas)}");
            Console.WriteLine($"Tentativas restantes: {tentativasRestantes}");
            Console.Write("Digite uma letra: ");
            char letra = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (!Char.IsLetter(letra))
            {
                Console.WriteLine("Por favor, digite uma letra válida.");
                continue;
            }

            if (letrasTentadas.Contains(letra))
            {
                Console.WriteLine("Você já tentou essa letra. Tente outra.");
                continue;
            }

            letrasTentadas.Add(letra);

            if (palavra.Contains(letra))
            {
                for (int i = 0; i < palavra.Length; i++)
                {
                    if (palavra[i] == letra)
                        letrasDescobertas[i] = letra;
                }
                Console.WriteLine("Acertou!");
            }
            else
            {
                tentativasRestantes--;
                Console.WriteLine("Errou!");
            }
        }

        if (new string(letrasDescobertas) == palavra)
            Console.WriteLine($"\nParabéns! Você ganhou! A palavra era '{palavra}'.");
        else
            Console.WriteLine($"\nFim de jogo! Você perdeu. A palavra era '{palavra}'.");

        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}
