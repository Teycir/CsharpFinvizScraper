#region

using System.Text;

#endregion

namespace Helpers
{
    public class Numerics
    {
        /// <summary>
        /// 	Extracts the numbers.
        /// </summary>
        /// <param name="datum"> The datum. </param>
        /// <returns> </returns>
        public static string ExtractNumbers(string datum)
        {
            const string numbers = "0123456789.";
            var numberBuilder = new StringBuilder();
            if (datum != null)
            {
                foreach (char c in datum)
                {
                    if (numbers.IndexOf(c) > -1)
                        numberBuilder.Append(c);
                }
            }
            return numberBuilder.ToString();
        }
    }
}