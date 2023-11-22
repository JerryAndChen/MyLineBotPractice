using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// AgentDataRepo 的摘要描述
/// </summary>
public class AgentDataRepo
{
    private SqlHelper _sqlHelper;
    private SqlConnection _conn;
    private DynamicParameters _params;
    public AgentDataRepo()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
        _sqlHelper = new SqlHelper();
        _conn = _sqlHelper.GetConnection();
    }
    public List<AgentData> GetReqAgentData(string cityId, string districtId, string storeId)
    {
        List<AgentData> list = null;
        string sqlStr = "select * from agent_data where cityId=@cityId and districtId=@districtId and storeId=@storeId";
        _params = new DynamicParameters();
        _params.Add("@cityId", cityId);
        _params.Add("@districtId", districtId);
        _params.Add("@storeId", storeId);
        using (_conn)
        {
            _conn.Open();
            list = _conn.Query<AgentData>(sqlStr, _params).ToList();
        }
        return list;
    }
    public void CreateAgentData(AgentData agentData)
    {
        string sqlStr = " insert into agent_data(applId, roleId, cityId, districtId, storeId, agtStartDate, agtEndDate, dcsnNo, dcsnName) " +
            " values (@applId, @roleId, @cityId, @districtId, @storeId, @agtStartDate, @agtEndDate, @dcsnNo, @dcsnName) ";
        _params = new DynamicParameters();
        _params.Add("@applId", agentData.ApplId);
        _params.Add("@roleId", agentData.RoleId);
        _params.Add("@cityId", agentData.CityId);
        _params.Add("@districtId", agentData.DistrictId);
        _params.Add("@storeId", agentData.StoreId);
        _params.Add("@agtStartDate", agentData.AgtStartDate);
        _params.Add("@agtEndDate", agentData.AgtEndDate);
        _params.Add("@dcsnNo", agentData.DcsnNo);
        _params.Add("@dcsnName", agentData.DcsnName);
        using (_conn)
        {
            _conn.Open();
            try
            {
                _conn.Execute(sqlStr, _params);
            }
            catch (Exception e)
            {
                Util.Log.LogToFile("DB_Error \n AgentDataRepo => CreateAgentData: \n", e.Message);
                throw new Exception("Error occurs when Create");
            }
        }

    }
}