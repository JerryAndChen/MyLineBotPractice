using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;
using Dapper;

/// <summary>
/// StoreDataRepo 的摘要描述
/// </summary>
public class StoreDataRepo
{
    private SqlHelper _sqlHelper = new SqlHelper();
    private SqlConnection _conn;
    private DynamicParameters _params;
    public StoreDataRepo()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
        _conn = _sqlHelper.GetConnection();
    }
    public Dictionary<string, string> GetStore(string cityCode, string districtCode)
    {
        Dictionary<string, string> map;
        string sqlStr = "select store_id, store from store_data where city_id=@cityId and district_id=@districtId";
        _params = new DynamicParameters();
        _params.Add("@cityId", cityCode);
        _params.Add("@districtId", districtCode);
        using (_conn)
        {
            _conn.Open();
            map = _conn.Query(sqlStr, _params).ToDictionary(d => (string)d.store_id, d => (string)d.store);
        }
        return map;
    }
    public string GetStore(string cityId, string districtId, string storeId)
    {
        string store;
        string sqlStr = "select store ";
        sqlStr += " from store_data ";
        sqlStr += " where city_id=@cityId and district_id=@districtId and store_id=@storeId ";
        _params = new DynamicParameters();
        _params.Add("@cityId", cityId);
        _params.Add("@districtId", districtId);
        _params.Add("@storeId", storeId);
        using (_conn)
        {
            _conn.Open();
            store = _conn.Query<string>(sqlStr, _params).FirstOrDefault();
        }
        return store;
    }
    public string GetMap()
    {
        string returnStr = "";
        List<dynamic> list;
        string sqlStr = " select city_id, city, district ";
        sqlStr += "  from store_data ";
        sqlStr += " group by city_id, city, district ";
        sqlStr += " order by cast(city_id as int) ";

        using (_conn)
        {
            _conn.Open();
            list = _conn.Query<dynamic>(sqlStr).ToList();
            //var data = from d in list
            //           group d by d.city;
            var data = list.GroupBy(d => d.city).ToDictionary(g => g.Key, g => g.Select(d => d.district).ToList());
            returnStr = JsonConvert.SerializeObject(data);
        }

        return returnStr;
    }
}