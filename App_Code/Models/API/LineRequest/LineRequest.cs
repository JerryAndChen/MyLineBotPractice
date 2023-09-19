using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// LineRequest 的摘要描述
/// </summary>
public class LineRequest
{
    private string _destination;
    private Events[] _events;
    public LineRequest()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //

    }

    public string Destination
    {
        get
        {
            return _destination;
        }

        set
        {
            _destination = value;
        }
    }

    public Events[] Events
    {
        get
        {
            return _events;
        }

        set
        {
            _events = value;
        }
    }
}