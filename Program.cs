using System;
using NagyAbel.Utils;
namespace NagyAbel
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Writer.Writeln("Welcome!");

            Game:
            string answer = Reader.ReadString("Would you like to play hangman?[yes/no]:", "yes", "no");
            if (answer == "yes")
            {
                Game game = new Game();
                game.ChooseDifficulty();
                game.Setup();

                while (game.state == GameState.Playing)
                {
                    game.DrawState();
                    game.TakeInput();
                    game.CheckForEnd();
                }

                game.DrawState();
                if (game.state == GameState.Win)
                {
                    Writer.Writeln("Congratulations, You Won!");
                }
                else
                {
                    Writer.Writeln("Ha,ha  maybe next time!");
                }

                string name = Reader.ReadString("Enter your name: ");
                Score.SaveScore(name,game.state == GameState.Win);
                ScoreData data = Score.ReadScores();
                data.Print();

                goto Game;


            }


        }
    }
}