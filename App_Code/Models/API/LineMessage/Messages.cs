using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Messages 的摘要描述
/// </summary>
public class Messages
{
    private string _type;
    private string _text;
    public Messages()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public Messages(string type, string text)
    {
        _type = type;
        _text = text;
    }

    public string type
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

    public string text
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

