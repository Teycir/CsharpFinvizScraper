#region

using TweetSharp;

#endregion

namespace Helpers
{
    public class TweetHelper
    {
        /// <summary>
        /// 	Ons the start.
        /// </summary>
        /// <param name="cKey"> The c key. </param>
        /// <param name="cSecret"> The c secret. </param>
        /// <param name="accessToken"> The access token. </param>
        /// <param name="tokenSecret"> The token secret. </param>
        /// <returns> </returns>
        private static TwitterService OnStart(string cKey, string cSecret, string accessToken, string tokenSecret)
        {
            var twitterApp = new TwitterService(cKey, cSecret);
            twitterApp.AuthenticateWith(accessToken, tokenSecret);
            return twitterApp;
        }


        /// <summary>
        /// 	Sends the tweet.
        /// </summary>
        /// <param name="message"> The message. </param>
        /// <param name="cKey"> The c key. </param>
        /// <param name="cSecret"> The c secret. </param>
        /// <param name="accessToken"> The access token. </param>
        /// <param name="tokenSecret"> The token secret. </param>
        public static void SendTweet(string message, string cKey, string cSecret, string accessToken, string tokenSecret)
        {
            var twitterApp = OnStart(cKey, cSecret, accessToken, tokenSecret);
            SendTweetOptions options = new SendTweetOptions();
            options.Status = message;
            twitterApp.SendTweet(options);
        }
    }
}