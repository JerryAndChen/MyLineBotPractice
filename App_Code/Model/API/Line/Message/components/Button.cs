using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Button 的摘要描述
/// </summary>
public class Button
{
    private string _type;
    private string _text;
    private string _value;
    public Button()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public Button(string type, string text, string value)
    {
        _type = type;
        _text = text;
        _value = value;
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

    public string Value
    {
        get
        {
            return _value;
        }

        set
        {
            _value = value;
        }
    }
}