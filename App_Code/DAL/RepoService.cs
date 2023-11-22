using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// RepoService 的摘要描述
/// </summary>
public class RepoService
{
    private static RepoService instance;
    public RepoService()
    {
        _user_repo = new user_data_repo();
        _city_repo = new city_map_repo();
        _store_repo = new store_data_repo();
        _agt_data_repo = new agent_data_repo();
        _agt_apply_repo = new agent_apply_repo();
        _agt_record_repo = new agent_record_repo();
    }
    public static RepoService getInstance()
    {
        if (instance == null)
        {
            instance = new RepoService();
        }
        return instance;
    }
    private user_data_repo _user_repo;
    private city_map_repo _city_repo;
    private store_data_repo _store_repo;
    private agent_data_repo _agt_data_repo;
    private agent_apply_repo _agt_apply_repo;
    private agent_record_repo _agt_record_repo;
    
    public user_data_repo user_repo() { return _user_repo; }
    public city_map_repo city_repo() { return _city_repo; }
    public store_data_repo store_repo() { return _store_repo; }
    public agent_data_repo agt_data_repo() { return _agt_data_repo; }
    public agent_apply_repo agt_apply_repo() { return _agt_apply_repo; }
    public agent_record_repo agt_record_repo() { return _agt_record_repo; }
}