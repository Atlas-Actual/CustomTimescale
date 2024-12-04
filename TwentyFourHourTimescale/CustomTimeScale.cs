using System;
using System.Windows.Forms;
using GTA;
using GTA.Chrono;
using GTA.Math;
using GTA.Native;
using GTA.UI;

namespace CustomTimescale
{
    public class Main : Script
    {
        bool firstTime = true;
        string ModName = "~c~Custom Timescale";
        string Developer = "~HUD_COLOUR_WAYPOINTDARK~Atlas~w~";
        string Version = "0.9";

        ScriptSettings config;
        int timeScale;

        public Main()
        {
            Tick += onTick;
            Interval = 10;
        }
        private void onTick(object sender, EventArgs e)
        {
            if (firstTime)
            {
                Notification.PostTicker("~g~Loaded~w~ " + ModName + " " + Version + " by " + Developer, true);

                config = ScriptSettings.Load("scripts\\CustomTimescale.ini");
                timeScale = config.GetValue<int>("Options", "Timescale", timeScale);
                if (timeScale >= 300)
                {
                    timeScale = 60;
                }
                else if (timeScale <= 1)
                {
                    timeScale = 60;
                }
                timeScale = timeScale * 1000;
                GameClock.MillisecondsPerGameMinute = timeScale;
                firstTime = false;
            }
        }

    }
}