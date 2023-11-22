using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserData 的摘要描述
/// </summary>
public class UserData
{
    private long _id;
    private string _userId;
    private string _userName;
    private string _userPicUrl;
    private string _sexType;
    private string _phone;
    private string _email;
    private string _birth;
    private string _roleId;
    private string _cityId;
    private string _districtId;
    private string _storeId;
    private string _registerTime;
    private string _lastLoginTime;
    public UserData()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    public long Id
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

    public string UserName
    {
        get
        {
            return _userName;
        }

        set
        {
            _userName = value;
        }
    }

    public string UserPicUrl
    {
        get
        {
            return _userPicUrl;
        }

        set
        {
            _userPicUrl = value;
        }
    }

    public string SexType
    {
        get
        {
            return _sexType;
        }

        set
        {
            _sexType = value;
        }
    }

    public string Phone
    {
        get
        {
            return _phone;
        }

        set
        {
            _phone = value;
        }
    }

    public string Email
    {
        get
        {
            return _email;
        }

        set
        {
            _email = value;
        }
    }

    public string Birth
    {
        get
        {
            return _birth;
        }

        set
        {
            _birth = value;
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

    public string RegisterTime
    {
        get
        {
            return _registerTime;
        }

        set
        {
            _registerTime = value;
        }
    }

    public string LastLoginTime
    {
        get
        {
            return _lastLoginTime;
        }

        set
        {
            _lastLoginTime = value;
        }
    }
}