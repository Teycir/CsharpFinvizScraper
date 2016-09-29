#region

using System.Diagnostics;

#endregion

namespace Helpers
{
    public class Processes
    {
        public static void KillProcess(string process)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName(process))
                {
                    proc.Kill();
                }
            }
            catch
            {
            }
        }
    }
}