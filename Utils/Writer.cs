namespace NagyAbel.Utils
{
    static class Writer
    {
        public static bool Write(string input, int delay = Globals.normal, bool clear = false)
        {
            if (clear) Console.Clear();

            if(delay == 0)
            {
                Console.Write(input);
                return true;
            }
            foreach (char c in input)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            return true;
        }

        public static bool Writeln(string input, int delay = 3, bool clear = false)
        {
            Write(input, delay, clear);
            Console.WriteLine();
            return true;
        }


    }
}