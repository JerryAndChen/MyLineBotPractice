using System;
using System.Collections.Generic;
using System.Dynamic;
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
            using (StreamReader input = new StreamReader(context.Request.InputStream))
            {
                requestBody = input.ReadToEnd();
            }
            if(requestBody != "")
            {
                lineRequest = JsonConvert.DeserializeObject<LineRequest>(requestBody);
                Util.Log.LogToFile("test", lineRequest.Events[0].Message.Text);

                //do Reply
                //string replyToken = lineRequest.Events[0].ReplyToken;
                //List<ILineMessage> messageList = new List<ILineMessage>();
                //messageList.Add(new TextMessage("Hello, Dr.Jerry"));
                //messageList.Add(new StickerMessage("446", "1988"));
                //List<Button> buttons = new List<Button>();
                //buttons.Add(new Button("uri", "Button", "http://localhost:8080"));
                //messageList.Add(new BubbleMessage("Hello World", "", "Hello, Dr.Jerry", "jerryTest", buttons));
                //APIUrl.Line.LineReply.doReply(LineMessage.createMessage(messageList), replyToken);

                //do Push
                //string userID = lineRequest.Events[0].Source.UserId;
                //APIUrl.Line.LinePushMsg.doPush(LineMessage.createMessage("text", new TextMessage("How are you, Jerry")), userID);
            }
            
        }
        catch(Exception e)
        {
            Util.Log.LogToFile("error", e.Message);
        }

        
    }
    
}