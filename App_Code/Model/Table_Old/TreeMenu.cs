using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// TreeMenu 的摘要描述
/// </summary>
public class TreeMenu
{
    private int _id;
    private string _menu_id;
    private string _level;
    private string _name;
    private string _url;
    private int _sort;
    private string _parent;
    public TreeMenu()
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

    public string Level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public string Url
    {
        get
        {
            return _url;
        }

        set
        {
            _url = value;
        }
    }

    public int Sort
    {
        get
        {
            return _sort;
        }

        set
        {
            _sort = value;
        }
    }

    public string Parent
    {
        get
        {
            return _parent;
        }

        set
        {
            _parent = value;
        }
    }

    public string Menu_id
    {
        get
        {
            return _menu_id;
        }

        set
        {
            _menu_id = value;
        }
    }
}