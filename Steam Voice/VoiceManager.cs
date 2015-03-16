using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Speech.Recognition;
using System.Windows.Forms;

namespace Steam_Voice
{
    class VoiceManager : SpeechRecognitionEngine
    {
        static Form1 formInstance = null;
        public VoiceManager(string steamID, Form1 form)
        {
            SpeechRecognitionEngine speechEngine = new SpeechRecognitionEngine();
            this.SetInputToDefaultAudioDevice();

            GrammarBuilder verbs = new GrammarBuilder();
            Choices verbChoices = new Choices("open", "close", "hide", "show", "run", "launch");
            verbs.Append(verbChoices, 0, 1);

            GrammarBuilder nouns = new GrammarBuilder();
            Choices nounChoices = new Choices("friends", "library", "my games", "store", "community", "my profile");
            nouns.Append(nounChoices, 0, 1);

            GrammarBuilder statuses = new GrammarBuilder();
            Choices statusChoices = new Choices("online", "offline", "away", "busy");
            statuses.Append(statusChoices, 0, 1);

            GrammarBuilder games = new GrammarBuilder();
            UserInfo.getGames(steamID);
            if(UserInfo.gameList.Count < 0)
            {
                MessageBox.Show("Error getting game list.\nPlease make sure your SteamID is correct and that your profile is public");
            }

            Choices gameChoices = new Choices();
            for (int i = 0; i < UserInfo.gameList.Count; i++)
            {
                gameChoices.Add(UserInfo.gameList.ElementAt(i).name);
            }
            games.Append(gameChoices, 0, 1);

            GrammarBuilder completeGrammar = new GrammarBuilder();

            completeGrammar.AppendWildcard();
            completeGrammar.Append(verbs);
            completeGrammar.AppendWildcard();
            completeGrammar.Append(nouns);
            completeGrammar.AppendWildcard();
            completeGrammar.Append(statuses);
            completeGrammar.AppendWildcard();
            completeGrammar.Append(games);

            Grammar grammar = new Grammar(completeGrammar);

            formInstance = form;
            this.LoadGrammar(grammar);
            this.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speechEngine_SpeechRecognized);
            this.RecognizeAsync(RecognizeMode.Multiple);
        }

        public static void speechEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            
            string words = e.Result.Text;


           //MessageBox.Show(words); For debugging, will display the words that it understood 

            if (words.Contains("run") || words.Contains("launch"))
            {
                foreach (GameInfo g in UserInfo.gameList)
                {
                    if (words.Contains(g.name))
                    {
                        formInstance.setStatusText("Launched " + g.name);
                        UserControl.launchGame(g.ID);
                    }
                }
            }
            else if (words.Contains("library") || words.Contains("my games")) //if (words.Contains("show") || words.Contains("open"))
            {
               formInstance.setStatusText("Opened your game library");
               UserControl.goTo("library");
            }
            else if (words.Contains("store"))
            {
               formInstance.setStatusText("Opened the store");
               UserControl.goTo("store");
            }
            else if (words.Contains("community"))
            {
                formInstance.setStatusText("Opened the community");
                UserControl.goTo("community");
            }
            else if (words.Contains("my profile"))
            {
                formInstance.setStatusText("Opened your profile");
                UserControl.goTo("my profile");
            }
            else if (words.Contains("friends"))
            {
                if (words.Contains("hide") || words.Contains("close"))
                {
                    formInstance.setStatusText("Hiding your friends");
                    UserControl.closeFriends();
                }
                else
                {
                    formInstance.setStatusText("Displaying your friends");
                    UserControl.openFriends();
                }
            }

            if (words.Contains("online"))
            {
                formInstance.setStatusText("Set your status to online");
                UserControl.setStatus("online");
            }
            else if (words.Contains("offline"))
            {
                formInstance.setStatusText("Set your status to offline");
                UserControl.setStatus("offline");
            }
            else if (words.Contains("away"))
            {
                formInstance.setStatusText("Set your status to away");
                UserControl.setStatus("away");
            }
            else if (words.Contains("busy"))
            {
                formInstance.setStatusText("Set your status to busy");
                UserControl.setStatus("busy");
            }
        }

    }
}
