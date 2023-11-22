using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Web;

/// <summary>
/// ApplyDataRepo 的摘要描述
/// </summary>
public class ApplyDataRepo
{
    private SqlHelper _sqlHelper;
    private SqlConnection _conn;
    private DynamicParameters _params;
    public ApplyDataRepo()
    {
        _sqlHelper = new SqlHelper();
    }
    public List<ApplyData> QueryApplyDataList(string dcsnNo)
    {
        List<ApplyData> list = new List<ApplyData>();
        string sqlStr = "select * from apply_data where dcsnNo=@dcsnNo and coalesce(isApprove,'')='' ";
        _params = new DynamicParameters();
        _params.Add("@dcsnNo", dcsnNo);
        using (_conn = _sqlHelper.GetConnection())
        {
            _conn.Open();
            list = _conn.Query<ApplyData>(sqlStr, _params).ToList();
        }
        return list;
    }
    public ApplyData QueryApplyData(string applId)
    {
        ApplyData applyData = null;
        string sqlStr = "select * from apply_data where id=@applId";
        _params = new DynamicParameters();
        _params.Add("@applId", applId);
        using (_conn = _sqlHelper.GetConnection())
        {
            try
            {
                _conn.Open();
                applyData = _conn.Query<ApplyData>(sqlStr, _params).SingleOrDefault();
            }
            catch(Exception e)
            {
                Util.Log.LogToFile("ApplyData => QueryApplyData exception", e.Message);
            }
            
        }
        return applyData;
    }
    public bool CreateApplyData(ApplyData applyData)
    {
        string sqlStr = " insert into apply_data(applNo,applName,applContent,applTime,startDate,endDate,dcsnNo,dcsnName,cityId,districtId,storeId) ";
        sqlStr += " values(@applNo,@applName,@applContent,@applTime,@startDate,@endDate,@dcsnNo,@dcsnName,@cityId,@districtId,@storeId) ";
        _params = new DynamicParameters();
        _params.Add("@applNo", applyData.ApplNo);
        _params.Add("@applName", applyData.ApplName);
        _params.Add("@applContent", applyData.ApplContent);
        _params.Add("@applTime", applyData.ApplTime);
        _params.Add("@startDate", applyData.StartDate);
        _params.Add("@endDate", applyData.EndDate);
        _params.Add("@dcsnNo", applyData.DcsnNo);
        _params.Add("@dcsnName", applyData.DcsnName);
        _params.Add("@cityId", applyData.CityId);
        _params.Add("@districtId", applyData.DistrictId);
        _params.Add("@storeId", applyData.StoreId);
        using (_conn = _sqlHelper.GetConnection())
        {
            _conn.Open();
            try
            {
                _conn.Execute(sqlStr, _params);
            }
            catch (Exception e)
            {
                Util.Log.LogToFile("DB_Error", e.Message);
                return false;
            }
        }

            return true;
    }
    public bool UpdateApplyData(ApplyData applyData)
    {
        string sqlStr = " update apply_data " +
            " set applContent=@applContent, startDate=@startDate, endDate=@endDate, dcsnContent=@dcsnContent, isApprove=@isApprove " +
            " where id=@applId"; 
        _params = new DynamicParameters();
        _params.Add("@applId", applyData.Id);
        _params.Add("@applContent", applyData.ApplContent);
        _params.Add("@startDate", applyData.StartDate);
        _params.Add("@endDate", applyData.EndDate);
        _params.Add("@dcsnContent", applyData.DcsnContent);
        _params.Add("@isApprove", applyData.IsApprove);
        using (_conn = _sqlHelper.GetConnection())
        {
            _conn.Open();
            try
            {
                _conn.Execute(sqlStr, _params);
            }
            catch (Exception e)
            {
                Util.Log.LogToFile("DB_Error", e.Message);
                return false;
            }
        }

        return true;
    }
}