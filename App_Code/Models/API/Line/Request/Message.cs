using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Message 的摘要描述
/// </summary>
public class Message
{
    private string _type;
    private string _id;
    private string _quoteToken;
    private string _text;
    public Message()
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

    public string Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    public string QuoteToken
    {
        get
        {
            return _quoteToken;
        }

        set
        {
            _quoteToken = value;
        }
    }

    public string Text
    {
        get
        {
            return _text;
        }

        set
        {
            _text = value;
        }
    }
}