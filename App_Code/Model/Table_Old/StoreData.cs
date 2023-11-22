using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// StoreData 的摘要描述
/// </summary>
public class StoreData
{
    private int _id;
    private string _store;
    private string _city;
    private string _city_id;
    private string _district;
    private string _district_id;
    private string _address;
    public StoreData()
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

    public string Store
    {
        get
        {
            return _store;
        }

        set
        {
            _store = value;
        }
    }

    public string City
    {
        get
        {
            return _city;
        }

        set
        {
            _city = value;
        }
    }

    public string City_id
    {
        get
        {
            return _city_id;
        }

        set
        {
            _city_id = value;
        }
    }

    public string District
    {
        get
        {
            return _district;
        }

        set
        {
            _district = value;
        }
    }

    public string District_id
    {
        get
        {
            return _district_id;
        }

        set
        {
            _district_id = value;
        }
    }

    public string Address
    {
        get
        {
            return _address;
        }

        set
        {
            _address = value;
        }
    }
}