using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bowling
{
    class ScoreCard
    {
        public string Frame { get; set; }
        public string Type { get; set; }
        public int Total { get; set; }
    }
    class Game
    {
        public static void Start()
        {
            int GameScore = 0;
            int Bonus = 0;
            List<ScoreCard> ScoreArray = new List<ScoreCard>();
            
            for (int i = 0; i < 10; i++)
            {
                int FirstTry = Game.Bowl.GetFirstScore();
                int SecondTry = Game.Bowl.GetSecondScore(FirstTry);
                int FrameTotal = (FirstTry + SecondTry);
                Console.WriteLine("\n-----Frame " + (i + 1) + "-----");
                Game.Bowl.Go(FirstTry, SecondTry);
                GameScore = (GameScore + FrameTotal + Bonus);
                

                //Put Score in array
                if (FirstTry == 10)
                {
                    ScoreArray.Add(new ScoreCard {Frame = $"F{i}", Type = "Strike", Total = FrameTotal });
                }
                else if(FrameTotal == 10)
                {
                    ScoreArray.Add(new ScoreCard { Frame = $"F{i}", Type = "Spare", Total = FrameTotal });
                }
                else
                {
                    ScoreArray.Add(new ScoreCard { Frame = $"F{i}", Type = "Normal", Total = FrameTotal });
                }
                
            }
            for (int i = 0; i < ScoreArray.Count; i++)
            {

                if (ScoreArray[i].Type == "Strike")
                {
                    if (i != 8)
                    {
                        Bonus = Bonus + (ScoreArray[i + 1].Total + ScoreArray[i + 2].Total);
                    }
                    else
                    {

                    }

                }
                else if (ScoreArray[i].Type == "Spare")
                {
                    if (i != 9)
                    {
                        Bonus = (Bonus + ScoreArray[i + 1].Total);
                    }
                    else
                    {


                    }
                }
                else
                {
                    Bonus = (Bonus + 0);
                }
            }
            Console.WriteLine("\n------------------");
            Console.WriteLine("\n  Total Score: " + GameScore);
            //Console.WriteLine("\n  Game (No Bonus) Score: " + GameScoreNoBonus);
            Console.WriteLine("  Bonus Score: " + Bonus);
            Console.WriteLine("  Grand Total: " + (GameScore + Bonus));
            Console.WriteLine("  Click any key to bowl again.");
            
            Console.ReadKey();
            Game.Start();

            

        }
        public class Bowl
        {

            private static readonly Random getrandom = new Random();
            public static int GetFirstScore()
            {
                int Score = getrandom.Next(1, 12) - 1;
                return Score;
            }
            public static int GetSecondScore(int input)
            {
                int PinsLeft = (10 - input) + 1;
                int Score = getrandom.Next(0,PinsLeft);
                return Score;
            }
            
            public static void Go(int FirstTry, int SecondTry)
            {
                
                if (FirstTry == 10 && SecondTry == 0)
                {
                    Console.WriteLine("  X");
                }
                else if (FirstTry + SecondTry == 10)
                {
                    Console.WriteLine("  " + FirstTry);
                    Console.WriteLine("  \\");
                }
                else
                {
                    Console.WriteLine("  " + FirstTry);
                    Console.WriteLine("  " + SecondTry);
                }

                Console.WriteLine("\n  Frame Total: " + (FirstTry + SecondTry));
                
            }
            
        }

    }
   
}
