using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/// <summary>
/// CityMapRepo 的摘要描述
/// </summary>
public class CityMapRepo
{
    private SqlHelper _sqlHelper = new SqlHelper();
    private SqlConnection _conn;
    private DynamicParameters _params;
    public CityMapRepo()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
        _conn = _sqlHelper.GetConnection();
    }
    public Dictionary<string, string> GetCity()
    {
        Dictionary<string, string> map;
        string sqlStr = "select code_id, code_name from city_map where code_level='1' order by code_id ";
        using (_conn)
        {
            _conn.Open();
            map = _conn.Query(sqlStr, _params).ToDictionary(d => (string)d.code_id, d => (string)d.code_name);
        }
        return map;
    }
    public Dictionary<string, string> GetDistrict(string cityCode)
    {
        Dictionary<string, string> map;
        string sqlStr = "select code_id, code_name from city_map where code_level='2' and up_code_id=@cityCode order by code_id ";
        _params = new DynamicParameters();
        _params.Add("@cityCode", cityCode);
        using (_conn)
        {
            _conn.Open();
            map = _conn.Query(sqlStr, _params).ToDictionary(d => (string)d.code_id, d => (string)d.code_name);
        }
        return map;
    }
    
}