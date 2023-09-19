using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Events 的摘要描述
/// </summary>
public class Events
{
    private string _type;
    private string _webhookEventId;
    private string _timestamp;
    private string _replyToken;
    private string _mode;
    private Message _message;
    private Source _source;
    public Events()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    public string Type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
        }
    }

    public string WebhookEventId
    {
        get
        {
            return _webhookEventId;
        }

        set
        {
            _webhookEventId = value;
        }
    }

    public string Timestamp
    {
        get
        {
            return _timestamp;
        }

        set
        {
            _timestamp = value;
        }
    }

    public string ReplyToken
    {
        get
        {
            return _replyToken;
        }

        set
        {
            _replyToken = value;
        }
    }

    public string Mode
    {
        get
        {
            return _mode;
        }

        set
        {
            _mode = value;
        }
    }

    public Message Message
    {
        get
        {
            return _message;
        }

        set
        {
            _message = value;
        }
    }

    public Source Source
    {
        get
        {
            return _source;
        }

        set
        {
            _source = value;
        }
    }
}