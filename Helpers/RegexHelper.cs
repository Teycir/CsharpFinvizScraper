#region

using System.Text.RegularExpressions;

#endregion

namespace Helpers
{
    public class RegexHelper
    {
        /// <summary>
        /// 	Valids the email.
        /// </summary>
        /// <param name="email"> The email. </param>
        /// <returns> </returns>
        public static bool ValidEmail(string email)
        {
            //^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$
            Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$");
            if (reg.IsMatch(email.Trim().ToUpper()))
                return true;
            else
                return false;
        }


        /// <summary>
        /// 	Numbers the ofletters.
        /// </summary>
        /// <param name="message"> The message. </param>
        /// <returns> </returns>
        public static int NumberOfletters(string message)
        {
            return Regex.Matches(message, @"[a-zA-Z]").Count;
        }


        /// <summary>
        /// 	Counts the characters.
        /// </summary>
        /// <param name="target"> The target. </param>
        /// <param name="text"> The text. </param>
        /// <returns> </returns>
        public static int CountCharacters(char target, string text)
        {
            int returnVal = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString().ToUpper() == target.ToString().ToUpper())
                    returnVal++;
            }
            return returnVal;
        }
    }
}