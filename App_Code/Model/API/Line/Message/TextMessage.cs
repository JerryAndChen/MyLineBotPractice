using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// TextMessage 的摘要描述
/// </summary>
public class TextMessage:ILineMessage
{
    private string _type = "text";
    private string _text;
    public TextMessage()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public TextMessage(string text)
    {
        _text = text;
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

    public string type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = "text";
        }
    }
}

