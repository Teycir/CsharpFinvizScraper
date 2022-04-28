#region

using System;
using System.Globalization;

#endregion

namespace Helpers
{
    public class Expiration
    {
        /// <summary>Gets the expiration date.</summary>
        /// <param name="expirationspan">The expirationspan.</param>
        /// <param name="datestart">The datestart.</param>
        /// <param name="daysAgo">The days ago.</param>
        /// <param name="daysLeft">The days left.</param>
        /// <param name="messagebefore">The messagebefore.</param>
        /// <param name="message">The message.</param>
        public static void GetExpirationDate(double expirationspan, string datestart, out double daysAgo,
                                             out double daysLeft, string messagebefore, out string message)
        {
            // Initialize a date in the past.
            // This is March 3, 2008.

            // 1.
            // Parse the date and put in DateTime object.
            if (datestart == null)
            {
                daysAgo = 0;
                daysLeft = 0;
                message = null;
                return;
            }
            DateTime startDate = DateTime.Parse(datestart);

            // 2.
            // Get the current DateTime.
            DateTime now = DateTime.Now;

            // 3.
            // Get the TimeSpan of the difference.
            TimeSpan elapsed = now.Subtract(startDate);

            // 4.
            // Get number of days ago.
            daysAgo = Math.Floor(elapsed.TotalDays);

            daysLeft = expirationspan - daysAgo;
            if (daysLeft <= 0)
                daysLeft = 0;

            message = messagebefore + daysLeft.ToString(CultureInfo.InvariantCulture);
        }
    }
}