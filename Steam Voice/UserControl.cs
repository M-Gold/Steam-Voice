using System;
using System.Windows.Forms;

namespace Steam_Voice
{
    public static class UserControl
    {
        public static void setStatus(string status)
        {
            WebBrowser wb = new WebBrowser();
            wb.Navigate("steam://friends/status/" + status);
        }

        public static void launchGame(string ID)
        {
            WebBrowser wb1 = new WebBrowser();
            wb1.Navigate("steam://run/" + ID);
        }

        public static void openFriends()
        {
            WebBrowser wb = new WebBrowser();
            wb.Navigate("steam://open/friends/");
        }
        public static void closeFriends()
        {
            System.Diagnostics.Process[] steamProcs = System.Diagnostics.Process.GetProcessesByName("Steam");
            foreach (System.Diagnostics.Process p in steamProcs)
            {
                if (p.MainWindowTitle == "Friends")
                {
                    p.CloseMainWindow();
                }
            }
        }
        

        public static void goTo(string location)
        {
            WebBrowser wb = new WebBrowser();

            switch (location)
            {
                case "library":
                    wb.Navigate("steam://open/games/");
                    break;

                case "store":
                    wb.Navigate("steam://store/");
                    break;

                case "community":
                    wb.Navigate("steam://url/CommunityHome/");
                    break;

                case "my profile":
                    wb.Navigate("steam://url/SteamIDPage/" + UserInfo.steamID);
                    break;
            }
        }



    }
}
