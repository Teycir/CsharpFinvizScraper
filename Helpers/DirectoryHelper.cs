#region

using System.IO;

#endregion

namespace Helpers
{
    internal class DirectoryHelper
    {
        public static void CreateDirectory(string path)
        {
            bool exists = Directory.Exists(path);

            if (!exists)
                Directory.CreateDirectory(path);
        }
    }
}