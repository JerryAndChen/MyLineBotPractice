using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CityMap 的摘要描述
/// </summary>
public class CityMap
{
    private int _id;
    private string _up_code_id;
    private string _code_id;
    private string _code_name;
    private string _code_level;
    public CityMap()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    public int Id
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

    public string Up_code_id
    {
        get
        {
            return _up_code_id;
        }

        set
        {
            _up_code_id = value;
        }
    }

    public string Code_id
    {
        get
        {
            return _code_id;
        }

        set
        {
            _code_id = value;
        }
    }

    public string Code_name
    {
        get
        {
            return _code_name;
        }

        set
        {
            _code_name = value;
        }
    }

    public string Code_level
    {
        get
        {
            return _code_level;
        }

        set
        {
            _code_level = value;
        }
    }
}