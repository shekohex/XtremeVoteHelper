using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace XtremeVoteHelper
{
    /// <summary>
    /// The Vote Controller API Interface for XtremeVote Server
    /// </summary>
    public class Controller
    {
        private readonly int servicePort;
        private readonly string serviceIP = "127.0.0.1";
        /// <summary>
        /// Create New Controller.
        /// </summary>
        /// <param name="port">XtremeVote Server Port.</param>
        public Controller(int port) => servicePort = port;
        /// <summary>
        /// Create a new Controller with IP
        /// </summary>
        /// <param name="ip">XtremeVote Server IP</param>
        /// <param name="port">XtremeVote Server PORT</param>
        public Controller(string ip, int port)
        {
            servicePort = port;
            serviceIP = ip;
        }

        /// <summary>
        /// Return the player vote points by it's username.
        /// If the player dose not exist in the database, then it will return 0.
        /// </summary>
        /// <param name="username">the player username.</param>
        /// <returns>Vote Points</returns>
        public async Task<int> GetPlayerPoints(string username)
        {
            var url = $"http://{serviceIP}:{servicePort}/points?u={username}";
            try
            {
                var result = await MakeHttpRequest(url, HttpMethod.Get);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return 0;
            }

        }

        /// <summary>
        /// Update The Player points with new pre-calculated points.
        /// </summary>
        /// <param name="username">the current player username</param>
        /// <param name="points">the new points.</param>
        /// <returns>The Updated User Points</returns>
        public async Task<int> SetPlayerPoints(string username, int points)
        {
            var url = $"http://{serviceIP}:{servicePort}/points?u={username}&p={points}";
            try
            {
                var result = await MakeHttpRequest(url, HttpMethod.Post);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }

        }

        private async Task<string> MakeHttpRequest(string url, HttpMethod method)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(method, url))
            using (var response = await client.SendAsync(request))
            {
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        $"Http Request Fail with Status Code: {response.StatusCode} and Content: {response.Content}"
                        );
                }

                return content;
            }
        }
    }
}
