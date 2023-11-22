using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;

/// <summary>
/// TreeMenuRepo 的摘要描述
/// </summary>
public class TreeMenuRepo
{
    private SqlHelper _sqlHelper = new SqlHelper();
    private SqlConnection _conn;
    private DynamicParameters _params;
    public TreeMenuRepo()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
        _conn = _sqlHelper.GetConnection();
    }
    public List<TreeMenu> GetTreeMenu(string roleId)
    {
        List<TreeMenu> menuList = new List<TreeMenu>();
        string sqlStr = " select a.* ";
        sqlStr += " from tree_menu a ";
        sqlStr += " inner join role_menu_auth b on b.tree_menu_id = a.menu_id ";
        sqlStr += " where b.job_role_id in(@roleId,'*') and a.cancel='N' ";
        sqlStr += " order by a.sort";
        _params = new DynamicParameters();
        _params.Add("@roleId", roleId);

        using (_conn)
        {
            _conn.Open();
            menuList = _conn.Query<TreeMenu>(sqlStr, _params).ToList();
        }

        return menuList;
    }
    public List<TreeMenu> GetTreeMenuNode(string roleId, string parentId)
    {
        List<TreeMenu> menuList = new List<TreeMenu>();
        string sqlStr = " select a.* ";
        sqlStr += " from tree_menu a ";
        sqlStr += " inner join role_menu_auth b on b.tree_menu_id = a.menu_id ";
        sqlStr += " where b.job_role_id in(@roleId,'*') and a.cancel='N' and a.parent=@parentId ";
        sqlStr += " order by a.sort";
        _params = new DynamicParameters();
        _params.Add("@roleId", roleId);
        _params.Add("@parentId", parentId);

        using (_conn)
        {
            _conn.Open();
            menuList = _conn.Query<TreeMenu>(sqlStr, _params).ToList();
        }

        return menuList;
    }
    public List<TreeMenu> GetTreeMenuRoot(string roleId)
    {
        List<TreeMenu> menuList= new List<TreeMenu>();
        string sqlStr = " select a.* ";
        sqlStr += " from tree_menu a ";
        sqlStr += " inner join role_menu_auth b on b.tree_menu_id = a.menu_id ";
        sqlStr += " where b.job_role_id in(@roleId,'*') and a.cancel='N' and a.parent='root' ";
        sqlStr += " order by a.sort";
        _params = new DynamicParameters();
        _params.Add("@roleId", roleId);

        using (_conn)
        {
            _conn.Open();
            menuList = _conn.Query<TreeMenu>(sqlStr, _params).ToList();
        }

            return menuList;
    }

    public List<TreeMenu> GetTreeMenuNodes(string parentId)
    {
        List<TreeMenu> menuList = new List<TreeMenu>();
        string sqlStr = " select * from tree_menu where parent=@parentId order by sort";
        _params = new DynamicParameters();
        _params.Add("@parentId", parentId);

        using (_conn)
        {
            _conn.Open();
            menuList = _conn.Query<TreeMenu>(sqlStr, _params).ToList();
        }

        return menuList;
    }
}