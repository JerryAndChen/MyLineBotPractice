using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

/// <summary>
/// LineMessage 的摘要描述
/// </summary>
public class LineMessage
{
    public LineMessage()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public static ExpandoObject createMessage(List<ILineMessage> messageList)
    {
        dynamic lineMessage = new ExpandoObject();
        lineMessage.messages = new ArrayList();
        for(var i = 0; i < messageList.Count; i++)
        {
            switch (messageList[i].type)
            {
                case "text":
                    TextMessage txtMessage = (TextMessage)messageList[i];
                    var txtSingle = new
                    {
                        type = "text",
                        text = txtMessage.text
                    };
                    lineMessage.messages.Add(txtSingle);
                    break;
                case "sticker":
                    StickerMessage stickerMessage = (StickerMessage)messageList[i];
                    var stickerSingle = new
                    {
                        type = "sticker",
                        packageId = stickerMessage.PackageId,
                        stickerId = stickerMessage.StickerId
                    };
                    lineMessage.messages.Add(stickerSingle);
                    break;
                case "image":
                    ImageMessage imageMessage = (ImageMessage)messageList[i];
                    var imageSingle = new
                    {
                        type = "image",
                        originalContentUrl = imageMessage.OriginalContentUrl,
                        previewImageUrl = imageMessage.PreviewImageUrl
                    };
                    lineMessage.messages.Add(imageSingle);
                    break;
                case "bubble":
                    BubbleMessage bubbleMessage = (BubbleMessage)messageList[i];
                    object header = null, hero = null, body = null, footer = null;

                    //Header
                    if(bubbleMessage.HeadTitle != "")
                    {
                        header = new
                        {
                            type="box",
                            layout = "vertical",
                            contents = new[]
                            {
                                new
                                {
                                    type = "text",
                                    text = bubbleMessage.HeadTitle
                                }
                            }
                        };
                    }
                    //Hero
                    if(bubbleMessage.Image != "")
                    {
                        hero = new
                        {
                            type = "image",
                            url = bubbleMessage.Image,
                            size = "full",
                            aspectRatio = "20:13",
                            aspectMode = "cover"
                        };
                    }
                    //Body
                    object title = new
                    {
                        type = "text",
                        text = bubbleMessage.Title,
                        weight = "bold",
                        size = "xl"
                    };
                    object description = new
                    {
                        type = "text",
                        text = bubbleMessage.Description,
                        color = "#aaaaaa",
                        size = "sm"
                    };
                    body = new
                    {
                        type = "box",
                        layout = "vertical",
                        contents = new []
                        {
                            title,
                            description
                        }
                    };
                    //Footer
                    if(bubbleMessage.Buttons.Count > 0)
                    {
                        ArrayList btnList = new ArrayList();
                        for(int b = 0; b < bubbleMessage.Buttons.Count; b++)
                        {
                            object btn = new
                            {
                                type = "button",
                                style = "link",
                                height = "sm",
                                action = new
                                {
                                    type = bubbleMessage.Buttons[b].Type,
                                    label = bubbleMessage.Buttons[b].Text,
                                    uri = bubbleMessage.Buttons[b].Value
                                }
                            };
                            btnList.Add(btn);
                        }
                        footer = new
                        {
                            type = "box",
                            layout = "vertical",
                            contents = btnList
                        };
                    }
                    
                    //Build Bubble
                    var bubbleSingle = new
                    {
                        type = "flex",
                        altText = "flex message",
                        contents = new
                        {
                            type="bubble",
                            header = header,
                            hero = hero,
                            body = body,
                            footer = footer
                        }
                    };
                    lineMessage.messages.Add(bubbleSingle);
                    break;
                default:
                    break;
            }
        }
        
        return lineMessage;
    }
}