using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// LineResponse 的摘要描述
/// </summary>
public class LineResponse
{
    private string _replyToken;
    private Messages[] _messages;
    public LineResponse()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    public string replyToken
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

    public Messages[] messages
    {
        get
        {
            return _messages;
        }

        set
        {
            _messages = value;
        }
    }
}