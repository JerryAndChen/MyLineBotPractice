using System;
using System.IO;
using System.Web;
using Newtonsoft.Json;

public partial class LineBot : System.Web.UI.Page
{
    public bool IsReusable
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public override void ProcessRequest(HttpContext context)
    {
        try
        {
            string requestBody = "";
            LineRequest lineRequest = new LineRequest();
            LineResponse lineResponse = new LineResponse();
            LinePush linePush = new LinePush();
            using (StreamReader input = new StreamReader(context.Request.InputStream))
            {
                requestBody = input.ReadToEnd();
            }
            if(requestBody != "")
            {
                lineRequest = JsonConvert.DeserializeObject<LineRequest>(requestBody);
                Util.Log.LogToFile("test", lineRequest.Events[0].Message.Text);
                //linePush.to = "";
                //linePush.messages = new Messages[] { new Messages("text", "1") };
                //APIUrl.LinePushMsg.DoPush(linePush);
                lineResponse.replyToken = lineRequest.Events[0].ReplyToken;
                lineResponse.messages = new Messages[] { new Messages("text", "Hello World"), new Messages("text","您說了"+lineRequest.Events[0].Message.Text) };
                APIUrl.LineReply.doReply(lineResponse);
            }
            
        }
        catch(Exception e)
        {
            Util.Log.LogToFile("error", e.Message);
        }

        
    }
    
}