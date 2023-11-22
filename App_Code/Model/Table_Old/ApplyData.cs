using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ApplyData 的摘要描述
/// </summary>
public class ApplyData
{
    private int _id;
    private string _applNo;
    private string _applName;
    private string _applContent;
    private string _applTime;
    private string _startDate;
    private string _endDate;
    private string _dcsnNo;
    private string _dcsnName;
    private string _dcsnContent;
    private string _dcsnTime;
    private string _isApprove;
    private string _cityId;
    private string _districtId;
    private string _storeId;
    public ApplyData()
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

    public string ApplNo
    {
        get
        {
            return _applNo;
        }

        set
        {
            _applNo = value;
        }
    }

    public string ApplName
    {
        get
        {
            return _applName;
        }

        set
        {
            _applName = value;
        }
    }

    public string ApplContent
    {
        get
        {
            return _applContent;
        }

        set
        {
            _applContent = value;
        }
    }

    public string ApplTime
    {
        get
        {
            return _applTime;
        }

        set
        {
            _applTime = value;
        }
    }

    public string StartDate
    {
        get
        {
            return _startDate;
        }

        set
        {
            _startDate = value;
        }
    }

    public string EndDate
    {
        get
        {
            return _endDate;
        }

        set
        {
            _endDate = value;
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

    public string DcsnContent
    {
        get
        {
            return _dcsnContent;
        }

        set
        {
            _dcsnContent = value;
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

    public string IsApprove
    {
        get
        {
            return _isApprove;
        }

        set
        {
            _isApprove = value;
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
}