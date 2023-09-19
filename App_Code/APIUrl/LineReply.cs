using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIUrl
{
    /// <summary>
    /// LineReply 的摘要描述
    /// </summary>
    public class LineReply
    {
        private static string _replyUrl = ConfigurationManager.AppSettings["reply_url"];
        private static string _accessToken = ConfigurationManager.AppSettings["channel_access_token"];
        //private static HttpClient _httpClient = new HttpClient();
        public LineReply()
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }
        public static void doReply(LineResponse lineResponse)
        {
            Task<string> test = doPost(lineResponse);

        }
        private static async Task<string> doPost(LineResponse lineResponse)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient _httpClient = new HttpClient();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(lineResponse), System.Text.Encoding.UTF8, "application/json");
            try
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                var response = await _httpClient.PostAsync(_replyUrl, httpContent).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Util.Log.LogToFile("success", response.StatusCode + "   " + response.Content);
                }
                
            }
            catch (Exception e)
            {
                Util.Log.LogToFile("reply failed", e.Message);
            }
            return "ok";
        }
    }
}
