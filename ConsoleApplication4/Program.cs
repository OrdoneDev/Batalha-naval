using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Desenvolvido por David Christian
             * Linhas compiladas 178Ln
               Batalha naval */

            //Estancia objeto de jogadores
            Jogador[] jogadores = new Jogador[2];
            jogadores[0] = new Jogador();
            jogadores[1] = new Jogador();

            string Jogador1, Jogador2, Atual = "";

            //Entre com os nomes dos jogadores
            Console.Write("Entre com o nome do primeiro jogador: ");
            Jogador1 = Console.ReadLine();
            Console.Write("Entre com o nome do segundo jogador: ");
            Jogador2 = Console.ReadLine();
            Console.Clear();

            byte i = 0;
            int t;

            // Posição dos navios
            for (byte x = 0; x <= 2; ++x)
            {
                t = 0;
                while (t <= 1)
                {
                    Atual = (i == 0) ? Jogador1 : Jogador2;
                    jogadores[i].Posicao(jogadores[i], i, Atual);
                    i = (i == 0) ? i = 1 : i = 0;
                    Console.Clear();
                    ++t;
                }
            }

            i = 1;

            //Jogo não acaba enquanto não há um vencedor
            do 
            {
                Console.ForegroundColor = ConsoleColor.White;
                i = (i == 1)? i = 0: i = 1;
                Atual = (i == 0) ? Jogador1 : Jogador2;
                Console.Clear();
                Console.WriteLine("É hora de atacar.");
                Console.WriteLine("O {0} deve jogar", Atual);
                jogadores[i].Jogada(jogadores[0], jogadores[1], i, Atual);
            } while (!jogadores[i].verifica);

            //Declara vencedor
            Console.WriteLine("O {0} venceu", Atual);
            Console.ReadKey();
        }
    }
}