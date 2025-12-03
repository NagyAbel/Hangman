using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace NagyAbel.Utils
{
    public static class Score
    {
        public static void SaveScore(string username, bool win){
            string path = Path.Combine("GameData", "scores.json");

            if (!File.Exists(path))
            {
                try
                {
                    File.Create(path);

                }
                //Pokemon exception :)
                catch (Exception)
                {
                    Writer.Writeln("[ERROR] Failed to create score file!",Globals.fast,true);
                    Environment.Exit(-1);
                }
            }

            //Reading scores and serializing
            string json = File.ReadAllText(path);
            var jsonData = new ScoreData();
            try
            {
                jsonData = JsonSerializer.Deserialize<ScoreData>(json);
            }
            catch (Exception){
                Writer.Writeln("[ERROR] Failed to load score data, loading empty!",Globals.fast,true);
            }


            ScoreData data  =jsonData ?? new ScoreData();
            if (data.scores.ContainsKey(username))
            {
                data.scores[username].total += 1;
                if(win)data.scores[username].win +=1;
            }
            else
            {   
                //Add new entry
                int score = Convert.ToInt32(win);
                data.scores.Add(username,new UserScore(score,1));
            }

            //Save the updated scores
            string jsonScores = JsonSerializer.Serialize<ScoreData>(data);
            File.WriteAllText(path,jsonScores);
        }

        public static ScoreData ReadScores()
        {
            string path = Path.Combine("GameData", "scores.json");

            if (!File.Exists(path))
            {
                return new ScoreData();
            }
            string json = File.ReadAllText(path);

            var jsonData = new ScoreData();
            try
            {
                jsonData = JsonSerializer.Deserialize<ScoreData>(json);
            }
            catch (Exception){
                Writer.Writeln("[ERROR] Failed to load score data, loading empty!",Globals.fast,true);
            }

            ScoreData data  =jsonData ?? new ScoreData();
            return data;
        }
    }

    public class ScoreData
    {
        public Dictionary<string,UserScore> scores{get; set;}
        public ScoreData()
        {
            scores = new Dictionary<string, UserScore>();
        }
        public void Print(){
        //Sort by number of wins
          var sortedDict = scores
            .OrderByDescending(x => x.Value.win)
            .Take(5)
            .ToDictionary(x => x.Key, x => x.Value);
        Writer.Writeln("Leaderboard:",Globals.slow,true);
          int i = 0;
          foreach(var entry in sortedDict){
                i++;
                Writer.Writeln("[" + i + "] " +  entry.Key + " " + entry.Value.win +"/" + entry.Value.total,Globals.normal,false);
          }
        }
    }
    public class UserScore
    {
        public int win{get; set;}
        public int total{get; set;}

        public UserScore(int win = 0, int total = 0 )
        {
            this.win = win;
            this.total = total;
        }
    }

}