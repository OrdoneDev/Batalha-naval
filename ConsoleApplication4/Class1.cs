using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Jogador
    {
        //Mapa do jogo
        public char[, ,] jogo = new char[8, 8, 2];

        //Lista de jogadores
        Jogador[] player = new Jogador[2];

        //Verifica se há vencedores
        public bool verifica = false;
        byte z = 0;

        //Linha e coluna do mapa
        string x, y;

        //Construtor
        public Jogador()
        {
            byte t = 0;
            while (t <= 1)
            {
                for (byte i = 0; i <= 7; ++i)
                {
                    for (byte j = 0; j <= 7; ++j)
                    {
                        jogo[j, i, t] = ' ';  
                    }
                }
                t++;
            }
        }

        //Exibe a tela para jogadas 
        public void Exibe(Jogador tela)
        {  
            byte t = 0;
            //t == 0 (Jogador) t == 1 (Jogada)
            while (t <= 1)
            {
                //Coluna
                for (byte i = 0; i <= 7; ++i)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (i == 0) 
                        Console.WriteLine("   [0][1][2][3][4][5][6][7]");
                    //Linha
                    for (byte j = 0; j <= 7; ++j)
                    {
                        switch (j)
                        {
                            case 0:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("[{0}]", i);
                                TelaCor(tela, j, i, t);
                                Console.Write("{0} |", tela.jogo[j, i, t]);
                                break;
                            case 1:
                                TelaCor(tela, j, i, t);
                                Console.Write("{0} |", tela.jogo[j, i, t]);
                                break;
                            case 2:
                                TelaCor(tela, j, i, t);
                                Console.Write("{0} | ", tela.jogo[j, i, t]);
                                break;
                            case 3:
                                TelaCor(tela, j, i, t);
                                Console.Write("{0}|", tela.jogo[j, i, t]);
                                break;
                            case 4:
                                TelaCor(tela, j, i, t);
                                Console.Write("{0} |", tela.jogo[j, i, t]);
                                break;
                            case 5:
                                TelaCor(tela, j, i, t);
                                Console.Write("{0} |", tela.jogo[j, i, t]);
                                break;
                            case 6:
                                TelaCor(tela, j, i, t);
                                Console.Write("{0} |", tela.jogo[j, i, t]);
                                break;
                            case 7:
                                TelaCor(tela, j, i, t);
                                Console.WriteLine(tela.jogo[j, i, t]);
                                break;
                            default:
                                break;
                        }
                    }
                    Console.WriteLine();
                }
                t++;
            }
        }

        //Colore o jogo
        public void TelaCor(Jogador tela, byte j, byte i, byte t)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            switch (tela.jogo[j, i, t])
            {
                case 'X':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 'N':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'A':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        //Jogada
        public void Jogada(Jogador player1, Jogador player2, byte i, string atual)
        {
            //Recebe jogadores
            player[0] = player1;
            player[1] = player2;

            //Jogada com validação
            do
            {

                do
                {
                    Console.Clear();
                    player[i].Exibe(player[i]);
                    Console.WriteLine("O {0} deve acatar", atual);
                    Console.Write("Escolha uma linha: ");
                    x = Console.ReadLine();
                } while (x.Length == 0 || JogadaInvalida(x));

                do
                {
                    Console.Write("Escolha uma coluna: ");
                    y = Console.ReadLine();
                } while (y.Length == 0 || JogadaInvalida(y));

                Console.Clear();
            } while (player[i].jogo[byte.Parse(y.ToString()), byte.Parse(x.ToString()), 1] == 'A' || player[i].jogo[byte.Parse(y.ToString()), byte.Parse(x.ToString()), 1] == 'X');

            //Marca o ataque e mostra o mapa
            player[i].Marca(i);
            player[i].Exibe(player[i]);
            Console.ReadKey();
        }

        //Posiciona navio
        public void Posicao(Jogador jogadores, byte i, string atual)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("O {0} deve posicionar o navio", atual);
                do
                {
                    Console.Write("Escolha uma linha: ");
                    x = Console.ReadLine();
                } while (x.Length == 0 || JogadaInvalida(x));

                do
                {
                    Console.Write("Escolha uma coluna: ");
                    y = Console.ReadLine();
                } while (y.Length == 0 || JogadaInvalida(y));
            } while (jogadores.jogo[byte.Parse(y.ToString()), byte.Parse(x.ToString()), 0] == 'N');

            jogadores.jogo[byte.Parse(y.ToString()), byte.Parse(x.ToString()), 0] = 'N';
            jogadores.Exibe(jogadores);
            Console.ReadKey();
        }

        //Bombardeia o mapa
        public void Marca(byte i)
        {
            byte j, k;

            j = (i == 0) ? j = 0 : j = 1;
            k = (i == 0) ? k = 1 : k = 0;

            if (player[k].jogo[byte.Parse(y.ToString()), byte.Parse(x.ToString()), 0] == 'N')
            {
                player[j].jogo[byte.Parse(y.ToString()), byte.Parse(x.ToString()), 1] = 'X';
                player[k].jogo[byte.Parse(y.ToString()), byte.Parse(x.ToString()), 0] = 'X';
                ++z;
                verifica = (z == 3) ? true : false;
            }
            else
            {
                player[j].jogo[byte.Parse(y.ToString()), byte.Parse(x.ToString()), 1] = 'A';
                player[k].jogo[byte.Parse(y.ToString()), byte.Parse(x.ToString()), 0] = 'A';
            }
        }

        //Verifica se o indice indicado ultrapassa os limites da matriz
        public bool JogadaInvalida(string x)
        {
            if (x != "0" && x != "1" && x != "2" && x != "3" && x != "4" && x != "5" && x != "6" && x != "7")
                return true;

            return false;
        }
    }
}