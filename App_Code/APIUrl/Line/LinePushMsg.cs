using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIUrl.Line
{
    /// <summary>
    /// LinePushMsg 的摘要描述
    /// </summary>
    public class LinePushMsg
    {
        private static string _pushUrl = ConfigurationManager.AppSettings["push_url"];
        private static string _accessToken = ConfigurationManager.AppSettings["channel_access_token"];
        private static HttpClient _httpClient;
        public LinePushMsg()
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }
        public static void doPush(ExpandoObject obj, string userID)
        {
            dynamic replyObj = obj;
            replyObj.to = userID;
            Task<bool> test = doPost(replyObj);
        }
        private static async Task<bool> doPost(ExpandoObject obj)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient _httpClient = new HttpClient();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(obj), System.Text.Encoding.UTF8, "application/json");
            Util.Log.LogToFile("pushMessage", JsonConvert.SerializeObject(obj));
            try
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                var response = await _httpClient.PostAsync(_pushUrl, httpContent).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Util.Log.LogToFile("success", response.StatusCode + "   " + response.Content);
                }

            }
            catch (Exception e)
            {
                Util.Log.LogToFile("reply failed", e.Message);
                return false;
            }
            return true;
        }
    }
}
