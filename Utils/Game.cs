namespace NagyAbel.Utils
{
    public class Game
    {
        private GameState state { get; set; }
        private string difficulty;

        private string word;
        private char[] guess;

        public Game()
        {
            difficulty = "";
            state = GameState.Setup;
            word = "";
            guess = new char[0];
        }




        public void ChooseDifficulty()
        {
            string[] keys = DataLoader.LoadWords();

            Writer.Writeln("Great!", Globals.slow, true);
            Writer.Writeln("Please choose a difficulty:", Globals.fast);
            int index = 0;
            int[] possible_answers = new int[keys.Length];
            foreach (var key in keys)
            {
                index++;
                possible_answers[index - 1] = index;
                string output = index.ToString() + "." + key;
                Writer.Writeln(output);
            }
            this.difficulty = keys[Reader.ReadInt("Chosen difficulty:", possible_answers)-1];
        }

        public void Setup()
        {
            word = DataLoader.GetRandomWord(difficulty);
            guess = new char[word.Length];
            Array.Fill(guess, '*');

            //Setup the guess!
            int reveal_count = Globals.lettersToReveal(word.Length);
            Random r = new Random();
            while (reveal_count > 0)
            {
                int random_index = r.Next(0, word.Length);
                if (guess[random_index] == '*')
                {
                    guess[random_index] = word[random_index];
                    reveal_count--;
                    for(int i=0; i<word.Length; i++)
                    {
                        if(word[i] == guess[random_index] && i!=random_index){
                            guess[i] = word[i];
                            reveal_count--;
                        }
                    }
                }
            }
            DataLoader.LoadFigures();

        }
        public void DrawState(int state)
        {
            Writer.Writeln("", 0, true);
            string[] figure = DataLoader.GetFigure(state);
            foreach (string row in figure)
            {
                Writer.Writeln(row, 0);
            }
            Console.WriteLine();
            Writer.Writeln("Word to guess:\n" + new string(guess));
        }

        public void TakeInput()
        {
            char input = Reader.ReadChar("Guess a letter:");
        }








    }

    enum GameState
    {
        Setup,
        Playing,
        Win,
        Loose,
    }
}