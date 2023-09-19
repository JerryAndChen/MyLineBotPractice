using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Source 的摘要描述
/// </summary>
public class Source
{
    private string _type;
    private string _userId;
    public Source()
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

    public string UserId
    {
        get
        {
            return _userId;
        }

        set
        {
            _userId = value;
        }
    }
}