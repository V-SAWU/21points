using System;
using System.Collections.Generic;
using System.Text;
using blackjack;

namespace ConsoleApplication1
{
    class Program
    {
        static Game game = new Game();
        static int score_wj =200;
        static void Main(string[] args)
        {
            string wish = "";
            string lab_score = "";

            Console.WriteLine("please Click any key to start the game");
            Console.ReadKey();
            while (true)
            {
                string message = "";
                Console.Clear();

                bool result = game.firstCicle(out message);

                if (result)
                {
                    score_wj = score_wj + game.score;
                    lab_score = score_wj.ToString();
                    if (restart())
                    {
                        Console.WriteLine("No gamble, come again (Y/N) ");
                        wish = Console.ReadLine();
                        if (wish.ToLower() == "y")
                        {
                            initial(); score_wj = 1000; lab_score = score_wj.ToString();
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    else initial();
                }
                Console.WriteLine("Please choose the amount of the bet (1=10, 2=20, 3=30, default 10). ");
                wish = Console.ReadLine();
                game.k = wish;

                if (!xianshi())
                {
                    continue;
                }

                Console.ReadKey();
            }
            Console.WriteLine("Enter anything to comtinue or enter No to stop! ");
        }

        static bool xianshi()
        {
            string a = "";
            string b = "";
            string message = "";
        
            if (game.hand_zj.cards[0] != null)
            {
                a += game.hand_zj.cards[0].value + " *";
            }

            foreach (Card k in game.hand_wj.cards)
            {
                if (k != null)
                {
                    b += k.value + " ";
                }
            }

            Console.Clear();
            Console.WriteLine("Current menoy" + score_wj + "\r\n");
            Console.WriteLine("banker：" + a + "\r\n");
            Console.WriteLine("player：" + b);
            Console.WriteLine("is it bid card(Y/N)");
            string wish = Console.ReadLine();
            if (wish.ToLower() == "y")
            {
                game.hitEvent(out message);
            }
            else
            {
                game.standEvent(out message);
            }

            if (message == "")
            {
                xianshi();
            }
            else
            {
                xianshi1();
                Console.WriteLine(message);
                Console.WriteLine("please Click any key to start the game");
                Console.ReadKey();
            }

            return false;
        }
        static void xianshi1()
        {
            Console.Clear();
            string a = "";
            string b = "";
            foreach (Card k in game.hand_zj.cards)
            {
                if (k != null)
                {
                    a += k.value + " ";
                }
            }

            foreach (Card k in game.hand_wj.cards)
            {
                if (k != null)
                {
                    b += k.value + " ";
                }
            }

            Console.WriteLine("banker：" + a + "\r\n");
            Console.WriteLine("player：" + b);
        }
            static void initial()
        {
            game.hand_wj = new Hand();
            game.hand_zj = new Hand();
            game.deck = new Deck();
            game.i = 0;
        }

        static bool restart()
        {
            if (score_wj <= 0)
            {
                return true;
            }
            else return false;
        }
    }
}
