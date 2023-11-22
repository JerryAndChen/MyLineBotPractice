using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// JobRole 的摘要描述
/// </summary>
public class JobRole
{
    private int _id;
    private string _role_id;
    private string _role_name;
    private string _role_auth;
    public JobRole()
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

    public string Role_id
    {
        get
        {
            return _role_id;
        }

        set
        {
            _role_id = value;
        }
    }

    public string Role_name
    {
        get
        {
            return _role_name;
        }

        set
        {
            _role_name = value;
        }
    }

    public string Role_auth
    {
        get
        {
            return _role_auth;
        }

        set
        {
            _role_auth = value;
        }
    }
}