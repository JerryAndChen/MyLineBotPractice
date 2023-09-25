using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// SqlHelper 的摘要描述
/// </summary>
public class SqlHelper
{
    private string _connStr = System.Configuration.ConfigurationManager.AppSettings["DB_connectionString"];
    public SqlHelper()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connStr);
    }
}