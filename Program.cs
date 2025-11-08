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
            string answer = Reader.ReadString("Would you like to play hangman?[yes/no]:", "yes", "no");

            if (answer == "yes")
            {
                Game game = new Game();
                game.ChooseDifficulty();
                game.Setup();
                game.DrawState(0);
                game.TakeInput();

            }


        }
    }


    //Console.WriteLine("  +---+");
    //Console.WriteLine("  |    |");
    //Console.WriteLine("  O    |");
    //Console.WriteLine(" /|\\   |");
    //Console.WriteLine(" / \\   |");
    //Console.WriteLine("       |");
    //Console.WriteLine("=========");
}