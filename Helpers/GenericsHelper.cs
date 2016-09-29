#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Helpers
{
    internal class GenericsHelper
    {
        public static int NumberOfOccurences(List<string> list,string val)
        {
            return list.Count(str => str == val);
        }
    }
}