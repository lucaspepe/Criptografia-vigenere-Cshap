using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirfraDeVigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao; // DECLARAÇÃO DE VARIÁVEIS
            string textoClaro, textoCifra, chave, ChaveCifra, cifra = "", decriptacao = "";
            char caracter, key1, key2, continuar;
            do
            {
                Console.WriteLine("\n=====================================================");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("||   PROGRAMA DE CRIPTOGRAFIA - CIFRA DE VIGENÈRE  ||");
                Console.ResetColor();
                Console.WriteLine("=====================================================\n");
                Console.WriteLine("\n     ESCOLHA UMA OPÇÃO ABAIXO");
                Console.WriteLine("__________________________________");
                Console.WriteLine("                                  |");
                Console.WriteLine("----> 1 - Criptografar            |");
                Console.WriteLine("----> 2 - Descriptografar         |");
                Console.WriteLine("----> 3 - Sair do programa        |");
                Console.WriteLine("__________________________________| \n");
                Console.Write("Digite uma opção: ");
                do // REPETIÇAO CASO DIGITO FOR MAIOR QUE 3
                {
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao > 3 || opcao < 1)
                        Console.Write("OPÇAO INVÁLIDA, DIGITE NOVAMENTE: ");
                } while (opcao > 3 || opcao < 1);


                switch (opcao) // ESCOLHA DAS OPÇÕES APRESENTADAS AO USUÁRIO
                {
                    case 1:
                        Console.WriteLine("\nOPÇÃO DIGITADA: CRIPTOGRAFAR");
                        Console.Write("\nDigite o texto a ser criptografado: ");
                        do // REPETIÇÃO CASO NENHUM TEXTO TENHA SIDO DIGITADO
                        {
                            textoClaro = Console.ReadLine();
                            if (textoClaro == null || textoClaro == "")
                                Console.Write("NENHUM TEXTO DIGITADO!!! DIGITE O TEXTO A SER CRIPTOGRAFADO: ");
                        } while (textoClaro == "");

                        do // REPITA ATÉ A CHAVE TER NO MÍNIMO 4 CARACTERES
                        {
                            Console.Write("\nDigite uma chave: ");
                            do // REPETIÇÃO CASO NENHUMA CHAVE TENHA SIDO DIGITADA
                            {
                                chave = Console.ReadLine();
                                if (chave == null || chave == "")
                                    Console.Write("NENHUMA CHAVE DIGITADA!!! DIGITE UMA CHAVE: ");
                            } while (chave == "");

                            if (chave.Length < 4) // VERIFICANDO TAMANHO DA CHAVE
                                Console.WriteLine("\nA CHAVE DEVE CONTER NO MÍNIMO 4 CARACTERES");
                        } while (chave.Length < 4);

                        for (int i = 0; i < textoClaro.Length; i++) // ESTRUTURA DE REPETIÇÃO PARA A CIFRAGEM
                        {
                            caracter = char.ToUpper(textoClaro[i]);
                            if (caracter < 48 || caracter > 90) // COMPARAÇÃO COM A TABELA ASCII
                            {
                                continue;
                            }
                            key1 = char.ToUpper(chave[i % chave.Length]);//CÁLCULO PARA A ENCRIPTAÇÃO
                            cifra += (char)((43 + (caracter % 48 + key1 % 48)) % 43 + 48);
                        }
                        Console.WriteLine("__________________________________________________________");     
                        Console.WriteLine("\nTEXTO CLARO:               " + textoClaro.ToUpper());
                        Console.WriteLine("CHAVE:                     " + chave.ToUpper());
                        Console.WriteLine("TEXTO CRIPTOGRAFADO:       " + cifra);
                        Console.WriteLine("__________________________________________________________");
                        cifra = "";
                        break;
                    case 2:

                        Console.WriteLine("\nOPÇÃO DIGITADA: DESCRIPTOGRAFAR");
                        Console.Write("\nDigite a mensagem a ser descriptografada: ");
                        do
                        {
                            textoCifra = Console.ReadLine();// REPETIÇÃO CASO NENHUM TEXTO TENHA SIDO DIGITADO
                            if (textoCifra == null || textoCifra == "")
                                Console.Write("NENHUM TEXTO DIGITADO!!! DIGITE O TEXTO A SER DESCRIPTOGRAFADO:");
                        } while (textoCifra == "");
                        Console.Write("\nDigite a chave: ");
                        do // REPETIÇÃO CASO NENHUMA CHAVE TENHA SIDO DIGITADA
                        {
                            ChaveCifra = Console.ReadLine();
                            if (ChaveCifra == null || ChaveCifra == "")
                                Console.Write("NENHUMA CHAVE DIGITADA!!! DIGITE UMA CHAVE:");
                        } while (ChaveCifra == "");

                        for (int i = 0; i < textoCifra.Length; i++) // ESTRUTURA DE REPETIÇÃO PARA A DECRIPTAÇAO
                        {
                            caracter = char.ToUpper(textoCifra[i]);
                            if (caracter < 48 || caracter > 90) // COMPARAÇÃO COM A TABELA ASCII
                            {
                                continue;
                            }
                            //CÁLCULO PARA A DECRIPTAÇÃO
                            key2 = char.ToUpper(ChaveCifra[i % ChaveCifra.Length]);
                            decriptacao += (char)((43 - (key2 % 48 - caracter % 48)) % 43 + 48);
                        }
                        Console.WriteLine("__________________________________________________________");
                        Console.WriteLine("\nTEXTO CRIPTOGRAFADO:       " + textoCifra.ToUpper());
                        Console.WriteLine("CHAVE:                     " + ChaveCifra.ToUpper());
                        Console.WriteLine("TEXTO CLARO:               " + decriptacao.ToUpper());
                        Console.WriteLine("__________________________________________________________");
                        decriptacao = "";
                        break;
                    case 3:
                        Console.WriteLine();
                        break;
                }
                Console.Write("\nDeseja sair [S/N]? "); 
                continuar = char.Parse(Console.ReadLine().ToLower());
                Console.Clear();
            } while (continuar == 'n'); // REPETIÇÃO PARA SAIR OU NÃO DO PROGRAMA

            Console.ReadKey();
        }
    }
}



