using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Speech.Recognition;
using System.Text.RegularExpressions;

namespace Steam_Voice
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        public void setStatusText(string newStatus)
        {
            lblStatus.Text = newStatus;

        }

        private void butStartClicked(object sender, EventArgs e)
        {
            if (!tbSteamID.Text.Equals(String.Empty))
            {
                //Instatiate a new VoiceManager speech engine with the entered SteamID
                SpeechRecognitionEngine speechEngine = new VoiceManager(tbSteamID.Text, this);
            }
            else
            {
                MessageBox.Show("Please enter your Steam ID");
                return;
            }
            gbStart.Visible = false;
            lblStatus.Visible = true;


        }



    }
}

