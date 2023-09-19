using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// LinePush 的摘要描述
/// </summary>
public class LinePush
{
    private string _to;
    private Messages[] _messages;
    public LinePush()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    public string to
    {
        get
        {
            return _to;
        }

        set
        {
            _to = value;
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