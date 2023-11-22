using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

/// <summary>
/// UserDataRepo 的摘要描述
/// </summary>
public class UserDataRepo
{
    private SqlHelper _sqlHelper = new SqlHelper();
    private SqlConnection _conn;
    private DynamicParameters _params;
    public UserDataRepo()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
        _conn = _sqlHelper.GetConnection();
    }
    public UserData GetUserDataById(string userId)
    {
        UserData userData;
        string queryStr = "select * from user_data where userId = @userId";
        _params = new DynamicParameters();
        _params.Add("@userId", userId);

        using (_conn)
        {
            _conn.Open();
            userData = _conn.QuerySingleOrDefault<UserData>(queryStr, _params);
        }
        return userData;
    }

    public UserData GetStoreDcsnData(string cityId, string districtId, string storeId)
    {
        UserData userData;
        string queryStr = "select * from user_data where cityId=@cityId and districtId=@districtId and storeId=@storeId and roleId='1'";
        _params = new DynamicParameters();
        _params.Add("@cityId", cityId);
        _params.Add("@districtId", districtId);
        _params.Add("@storeId", storeId);

        using (_conn)
        {
            _conn.Open();
            userData = _conn.QuerySingleOrDefault<UserData>(queryStr, _params);
        }
        return userData;
    }
    public bool CreateUserData(UserData userData)
    {
        bool createSuccess = true;
        string sqlStr = "insert into user_data(userId, userName, userPicUrl, sexType, phone, email, birth, roleId, cityId, districtId, storeId, registerTime, lastLoginTime) "
            +" values (@userId, @userName, @userPicUrl, @sexType, @phone, @email, @birth, @roleId, @cityId, @districtId, @storeId, @registerTime, @lastLoginTime)";
        _params = new DynamicParameters();
        _params.Add("@userId", userData.UserId);
        _params.Add("@userName", userData.UserName);
        _params.Add("@userPicUrl", userData.UserPicUrl);
        _params.Add("@sexType", userData.SexType);
        _params.Add("@phone", userData.Phone);
        _params.Add("@email", userData.Email);
        _params.Add("@birth", userData.Birth);
        _params.Add("@roleId", userData.RoleId);
        _params.Add("@cityId", userData.CityId);
        _params.Add("@districtId", userData.DistrictId);
        _params.Add("@storeId", userData.StoreId);
        _params.Add("@registerTime", userData.RegisterTime);
        _params.Add("@lastLoginTime", userData.LastLoginTime);

        using (_conn)
        {
            _conn.Open();

            try
            {
                _conn.Execute(sqlStr, _params);
            }
            catch(Exception e)
            {
                Util.Log.LogToFile("DB_Error", e.Message);
                createSuccess = false;
            }
            
        }
        return createSuccess;
    }
}