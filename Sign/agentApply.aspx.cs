using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sign_agentApply : System.Web.UI.Page
{
    user_data user;
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        user = Master.user;
        id = Util.Common.parseInt(Request["id"]);
        if (!IsPostBack)
        {
            BuildFieldData();
        }
    }
    private void BuildFieldData()
    {
        agent_data agData = RepoService.getInstance().agt_data_repo().doQueryOne(a => a.id == id);
        store_data store = RepoService.getInstance().store_repo().doQueryOne(s => s.city_id == agData.cityId && s.district_id == agData.districtId && s.store_id == agData.storeId);
        txtCity.Text = store.city;
        txtDistrict.Text = store.district;
        txtStore.Text = store.store;
        txtAddress.Text = store.address;
        txtRole.Text = agData.roleId == "1" ? "店長" : "員工";
        txtRoleCnt.Text = agData.roleCnt.ToString();
        txtDescription.Text = agData.agtDescription;
        txtStartDate.Text = agData.agtStartDate.ToString("g");
        txtEndDate.Text = agData.agtEndDate.ToString("g");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (CreateData())
            {
                //create data success message
                ClientScript.RegisterStartupScript(typeof(Page), "agentApplyCreateFailed", "showMsg(\"申請成功\");", true);
            }
        }
    }
    private bool CreateData()
    {
        int applCnt = RepoService.getInstance().agt_apply_repo().doQueryAll(a => a.agtId == id && a.applNo == user.userId).Count;
        if(applCnt > 0)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "agentApplyCreateFailed", "showMsg(\"您已申請此工作支援\");", true);
            return false;
        }

        try
        {
            agent_apply appl = new agent_apply();
            appl.agtId = id;
            appl.applNo = user.userId;
            appl.applName = user.userName;
            appl.applTime = DateTime.Now;
            RepoService.getInstance().agt_apply_repo().doCreate(appl);
        }
        catch(Exception ex)
        {
            Util.Log.LogToFile("agent_apply create failed:\n", ex.Message);
            ClientScript.RegisterStartupScript(typeof(Page), "agentApplyCreateFailed", "showMsg(\"申請失敗\");", true);
            return false;
        }
        return true;
    }
}