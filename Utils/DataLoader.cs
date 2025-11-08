using System;
using System.Net;
using System.Threading;
using System.Text.Json;
using System.Linq;
namespace NagyAbel.Utils
{
    public static class DataLoader
    {
        private static Dictionary<string, string[]> word_data = new Dictionary<string, string[]>();
        private static Dictionary<int, string[]> figure_data = new Dictionary<int, string[]>();
        public static string[] LoadWords()
        {
            //We have already loaded data
            if (word_data.Keys.Count > 0) return word_data.Keys.ToArray();

            string path = Path.Combine("GameData", "words.json");
            if (!File.Exists(path))
            {
                Writer.Writeln("[  ⚠️  ] Word Data file is missing!", Globals.fast, true);
                Environment.Exit(-1);
            }

            try
            {
                string json = File.ReadAllText(path);
                var jsonData = JsonSerializer.Deserialize<Dictionary<string, string[]>>(json);
                if (jsonData == null)
                {
                    Writer.Writeln("[ERROR] The words file is empty, please add some words!", Globals.fast, true);
                    Environment.Exit(-1);
                }

                foreach (var key in jsonData.Keys) word_data[key] = jsonData[key];

                if (word_data.Count <= 0)
                {
                    Writer.Writeln("[ERROR] The words file is empty, please add some words!", Globals.fast, true);
                    Environment.Exit(-1);
                }

            }
            catch (Exception)
            {
                Writer.Writeln("[ERROR]There was an error loading the words file:!", 0, true);
                Environment.Exit(-1);
            }
            return word_data.Keys.ToArray();
        }
        public static string GetRandomWord(string dif)
        {
            if (word_data.Count == 0) LoadWords();

            Random random = new Random();
            string[] list = word_data[dif];
            int random_num = random.Next(0, list.Length);

            return list[random_num];
        }


        public static void LoadFigures()
        {
            //We have already loaded data
            if (figure_data.Keys.Count > 0) return;

            string path = Path.Combine("GameData", "figure.json");
            if (!File.Exists(path))
            {
                Writer.Writeln("[  ⚠️  ] Figure file is missing!", Globals.fast, true);
                Environment.Exit(-1);
            }

            try
            {
                string json = File.ReadAllText(path);
                var jsonData = JsonSerializer.Deserialize<Dictionary<int, string[]>>(json);
                if (jsonData == null)
                {
                    Writer.Writeln("[ERROR] The figure file is empty, please set the figures!", Globals.fast, true);
                    Environment.Exit(-1);
                }
                foreach (var key in jsonData.Keys)
                {
                    figure_data[key] = jsonData[key];
                }
                if (figure_data.Count <= 0)
                {
                    Writer.Writeln("[ERROR] The figure file is empty, please set the figures!", Globals.fast, true);
                    Environment.Exit(-1);
                }

            }
            catch (Exception)
            {
                Writer.Writeln("[ERROR]There was an error loading the data file!", 0, true);
                Environment.Exit(-1);
            }

        }

        public static string[] GetFigure(int state)
        {
            if (figure_data.Count == 0) LoadFigures();

            if (!figure_data.ContainsKey(state)){
                Writer.Writeln("[error] Sate not found, check the figure file!", 0, true);
                Environment.Exit(-1);
            }
            if (figure_data[state].Length == 0){
                Writer.Writeln("[error] Sate empty, check the figure file!", 0, true);
                Environment.Exit(-1);
            }
            return figure_data[state];
        }
    }
}