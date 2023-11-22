using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AgentData 的摘要描述
/// </summary>
public class AgentData
{
    private int _id;
    private int _applId;
    private string _roleId;
    private string _cityId;
    private string _districtId;
    private string _storeId;
    private string _agtNo;
    private string _agtName;
    private string _agtStartDate;
    private string _agtEndDate;
    private string _agtApplTime;
    private string _dcsnNo;
    private string _dcsnName;
    private string _dcsnTime;
    public AgentData()
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

    public int ApplId
    {
        get
        {
            return _applId;
        }

        set
        {
            _applId = value;
        }
    }

    public string RoleId
    {
        get
        {
            return _roleId;
        }

        set
        {
            _roleId = value;
        }
    }

    public string CityId
    {
        get
        {
            return _cityId;
        }

        set
        {
            _cityId = value;
        }
    }

    public string DistrictId
    {
        get
        {
            return _districtId;
        }

        set
        {
            _districtId = value;
        }
    }

    public string StoreId
    {
        get
        {
            return _storeId;
        }

        set
        {
            _storeId = value;
        }
    }

    public string AgtNo
    {
        get
        {
            return _agtNo;
        }

        set
        {
            _agtNo = value;
        }
    }

    public string AgtName
    {
        get
        {
            return _agtName;
        }

        set
        {
            _agtName = value;
        }
    }

    public string AgtStartDate
    {
        get
        {
            return _agtStartDate;
        }

        set
        {
            _agtStartDate = value;
        }
    }

    public string AgtEndDate
    {
        get
        {
            return _agtEndDate;
        }

        set
        {
            _agtEndDate = value;
        }
    }

    public string AgtApplTime
    {
        get
        {
            return _agtApplTime;
        }

        set
        {
            _agtApplTime = value;
        }
    }

    public string DcsnNo
    {
        get
        {
            return _dcsnNo;
        }

        set
        {
            _dcsnNo = value;
        }
    }

    public string DcsnName
    {
        get
        {
            return _dcsnName;
        }

        set
        {
            _dcsnName = value;
        }
    }

    public string DcsnTime
    {
        get
        {
            return _dcsnTime;
        }

        set
        {
            _dcsnTime = value;
        }
    }
}