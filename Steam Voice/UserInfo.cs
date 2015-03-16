using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Steam_Voice
{

    static class UserInfo
    {
        public static List<GameInfo> gameList = new List<GameInfo>();
        public static string steamID, userName;

        public static List<GameInfo> getGames(string username)
        {
            string downloadString = "";
            string gameName, gameID;
            List<GameInfo> poop = new List<GameInfo>();


            System.Net.WebClient client = new System.Net.WebClient();
            try
            {
                downloadString = client.DownloadString("http://steamcommunity.com/id/" + username + "/games?tab=all&xml=1"); //this can fail when no inernet or steam is down.. needs a 'try'
            }
            catch
            {
                MessageBox.Show("Unable to connect to steam");
                return null;
            }

            Regex r = new Regex(Regex.Escape("<game>") + "(.*?)" + Regex.Escape("</game>"), RegexOptions.Singleline);
            MatchCollection matches = r.Matches(downloadString);
            if (matches.Count <= 0)
            {
                return gameList;
            }


            foreach (Match m in matches)
            {
                Regex r2 = new Regex(Regex.Escape("<appID>") + "(.*?)" + Regex.Escape("</appID>"));
                Match m2 = r2.Match(m.ToString());
                gameID = m2.ToString().Replace("<appID>", "").Replace("</appID>", "");

                r2 = new Regex(Regex.Escape("<name><![CDATA[") + "(.*?)" + Regex.Escape("]]></name>"));
                m2 = r2.Match(m.ToString());
                gameName = m2.ToString().Replace("<name><![CDATA[", "").Replace("]]></name>", "");

                GameInfo newGame = new GameInfo();
                newGame.ID = gameID;
                newGame.name = gameName;

                gameList.Add(newGame);

            }


            r = new Regex(Regex.Escape("<steamID64>") + "(.*?)" + Regex.Escape("</steamID64>"));
            Match idMatch = r.Match(downloadString);
            steamID = idMatch.ToString().Replace("<steamID64>", "").Replace("</steamID64>", "");


            return gameList;
        }

    }
}
