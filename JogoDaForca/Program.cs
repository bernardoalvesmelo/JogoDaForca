namespace JogoDaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = CriarArrayPalavras();
            Random aleatorio = new Random();
            char[] palavraSecreta = FormatarPalavra(palavras[aleatorio.Next(0, palavras.Length)]).ToCharArray();
            char[] letrasDescobertas = new String('_', palavraSecreta.Length).ToCharArray();
            int tentativas = 5;
            string resultado = "Você perdeu!";
            while (tentativas > 0)
            {
                if (new string(palavraSecreta) == new string(letrasDescobertas))
                {
                    resultado = "Você venceu!";
                    break;
                }
                ReceberTentativa(ref tentativas, palavraSecreta, letrasDescobertas);
            }
            DesenharBoneco(tentativas);
            Console.WriteLine(resultado);
            Console.WriteLine("A palavra era " + new string(palavraSecreta));
            Console.ReadLine();
        }

        static void ReceberTentativa(ref int tentativas, char[] palavraSecreta, char[] letrasDescobertas)
        {
            DesenharBoneco(tentativas);
            Console.WriteLine("Tentativas Restantes: " + tentativas);
            Console.WriteLine(new string(letrasDescobertas));
            Console.Write("Digite uma Letra: ");
            char letra = Convert.ToChar(Console.ReadLine().ToUpper());
            if (VerificacaoLetra(letra, palavraSecreta, letrasDescobertas))
            {
                Console.WriteLine("Acertou a letra!");
            }
            else
            {
                tentativas--;
                Console.WriteLine("Errou a letra!");
            }

            Console.ReadLine();
            Console.Clear();
        }

        static bool VerificacaoLetra(char letra, char[] palavraSecreta, char[] letrasDescobertas)
        {
            bool ehCorreta = false;
            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                if (letra == palavraSecreta[i])
                {
                    ehCorreta = true;
                    letrasDescobertas[i] = letra;
                }
            }

            return ehCorreta;
        }

        static string[] CriarArrayPalavras()
        {
            return "ABACATE,ABACAXI,ACEROLA,AÇAÍ,ARAÇA,ABACATE,BACABA,BACURI,BANANA,CAJÁ,CAJÚ,CARAMBOLA,CUPUAÇU,GRAVIOLA,GOIABA,JABUTICABA,JENIPAPO,MAÇÃ,MANGABA,MANGA,MARACUJÁ,MURICI,PEQUI,PITANGA,PITAYA,SAPOTI,TANGERINA,UMBU,UVA,UVAIA".Split(',');
        }

        static void DesenharBoneco(int tentativas)
        {
            string linha = " " + new String('_', 10);
            Console.WriteLine(linha);
            linha = " |/";
            linha += new String(' ', 7);
            linha += "|";
            Console.WriteLine(linha);
            linha = " |";
            linha += new String(' ', 8);
            if (tentativas > 0)
            {
                linha += "O";
            }

            Console.WriteLine(linha);
            linha = " |";
            linha += new String(' ', 7);
            if (tentativas > 2)
            {
                linha += "-";
            }
            else
            {
                linha += " ";
            }

            if (tentativas > 1)
            {
                linha += "X";
            }

            if (tentativas > 3)
            {
                linha += '-';
            }

            Console.WriteLine(linha);
            linha = " |";
            linha += new String(' ', 8);
            if (tentativas > 4)
            {
                linha += 'X';
            }

            Console.WriteLine(linha);
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            linha = "_|____";
            Console.WriteLine(linha);
        }

        static string FormatarPalavra(string palavra)
        {
            string acentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûù";
            string formato = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuu";

            for (int i = 0; i < acentos.Length; i++)
            {
                palavra = palavra.Replace(acentos[i] + "", formato[i] + "");
            }
            return palavra;
        }

    }
}