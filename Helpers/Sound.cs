#region

using System;
using System.Media;

#endregion

namespace Helpers
{
    public class Sound
    {
        public static void PlayAlert(string sound)
        {
            string mBaseDir = AppDomain.CurrentDomain.BaseDirectory +
                              AppDomain.CurrentDomain.RelativeSearchPath;
            (new SoundPlayer(mBaseDir + sound + ".wav")).Play();
        }
    }
}