using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace APIUrl
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
        public static void DoPush(LinePush linePush)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(linePush), System.Text.Encoding.UTF8, "application/json");
            try
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                HttpStatusCode statusCode = _httpClient.PostAsync(_pushUrl, httpContent).Result.StatusCode;
                //Util.Log.LogToFile("success", strResponse);
            }
            catch (Exception e)
            {
                Util.Log.LogToFile("reply failed", e.Message);
            }
        }
    }
}
