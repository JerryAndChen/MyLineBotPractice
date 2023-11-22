using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sign_agentForm : System.Web.UI.Page
{
    user_data user;
    int id;
    string dcsnNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        user = Master.user;
        id = Util.Common.parseInt(Request["id"]);
        dcsnNo = Request["dcsnNo"];
        if (!IsPostBack)
        {
            addOption(ref ddlRoleCnt, 1, 10, false);
            addOption(ref ddlStartH, 0, 23, true);
            addOption(ref ddlStartT, 0, 59, true);
            addOption(ref ddlEndH, 0, 23, true);
            addOption(ref ddlEndT, 0, 59, true);
            txtStartD.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtEndD.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BuildFieldData();
        }
        BuildBtn();
    }
    public void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            System.Web.UI.WebControls.Button btn =  (System.Web.UI.WebControls.Button)sender;
            if (btn.CommandName == "create")
            {
                if (CreateData())
                {
                    //List<ILineMessage> messageList = new List<ILineMessage>();
                    //messageList.Add(new TextMessage("人力支援需求資訊已張貼至系統，待支援者申請配對"));
                    //List<Button> buttons = new List<Button>();
                    //buttons.Add(new Button("uri", "查詢支援配對申請", "https://liff.line.me/2000626468-ZQE950nX/?state=Sign/applRecord.aspx?id="+id));
                    //messageList.Add(new BubbleMessage("您好", "", "已張貼人力支援需求", "已張貼需求資訊，待支援者申請配對", buttons));
                    //string jsonMsg = JsonConvert.SerializeObject(LineMessage.createMessage(messageList));
                    //ClientScript.RegisterStartupScript(typeof(Page), "CreateAgentDataSuccessful", "createSuccess(" + jsonMsg + ");", true);
                    Util.Common.sendMail();
                }
            }else if(btn.CommandName == "update")
            {
                if (UpdateData())
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "CreateAgentDataSuccessful", "showMsgAndGoBack(\"修改成功\");", true);
                }
            }
            
        }
        
    }
    public bool CreateData()
    {
        try
        {
            agent_data agt = new agent_data();
            agt.title = txtTitle.Text;
            agt.roleId = ddlRole.SelectedValue;
            agt.roleCnt = Util.Common.parseInt(ddlRoleCnt.SelectedValue);
            agt.cityId = user.cityId;
            agt.districtId = user.districtId;
            agt.storeId = user.storeId;
            agt.agtStartDate = Util.Common.formatDateTime(txtStartD.Text, ddlStartH.SelectedValue, ddlStartT.SelectedValue);
            agt.agtEndDate = Util.Common.formatDateTime(txtEndD.Text, ddlEndH.SelectedValue, ddlEndT.SelectedValue);
            agt.agtDescription = txtDescription.Text;
            agt.dcsnNo = user.userId;
            agt.dcsnName = user.userName;
            RepoService.getInstance().agt_data_repo().doCreate(agt);

            id = (int)agt.id;
        }
        catch (Exception ex)
        {
            Util.Log.LogToFile("agent data create failed:\n", ex.Message);
            ClientScript.RegisterStartupScript(typeof(Page), "agentCreateFailed", "showMsg(\"新增失敗\");", true);
            return false;
        }
        return true;
    }
    public bool UpdateData()
    {
        try
        {
            agent_data agt = RepoService.getInstance().agt_data_repo().doQueryOne(a => a.id == id && a.dcsnNo==dcsnNo);
            agt.title = txtTitle.Text;
            agt.roleId = ddlRole.SelectedValue;
            agt.roleCnt = Util.Common.parseInt(ddlRoleCnt.SelectedValue);
            agt.cityId = user.cityId;
            agt.districtId = user.districtId;
            agt.storeId = user.storeId;
            agt.agtStartDate = Util.Common.formatDateTime(txtStartD.Text, ddlStartH.SelectedValue, ddlStartT.SelectedValue);
            agt.agtEndDate = Util.Common.formatDateTime(txtEndD.Text, ddlEndH.SelectedValue, ddlEndT.SelectedValue);
            agt.agtDescription = txtDescription.Text;
            agt.dcsnNo = user.userId;
            agt.dcsnName = user.userName;
            RepoService.getInstance().agt_data_repo().doUpdate(agt);
        }
        catch (Exception ex)
        {
            Util.Log.LogToFile("agent data update failed:\n", ex.Message);
            ClientScript.RegisterStartupScript(typeof(Page), "agentUpdateFailed", "showMsg(\"修改失敗\");", true);
            return false;
        }
        return true;
    }
    public void BuildFieldData()
    {
        string city_id = user.cityId;
        string district_id = user.districtId;
        string store_id = user.storeId;
        if(id != 0)
        {
            agent_data agt = RepoService.getInstance().agt_data_repo().doQueryOne(a => a.id == id && a.dcsnNo==dcsnNo);
            txtTitle.Text = agt.title;
            ddlRole.SelectedValue = agt.roleId;
            ddlRoleCnt.SelectedValue = agt.roleCnt.ToString();
            txtDescription.Text = agt.agtDescription;
            txtStartD.Text = agt.agtStartDate.ToString("yyyy-MM-dd");
            ddlStartH.SelectedValue = agt.agtStartDate.ToString("HH");
            ddlStartT.SelectedValue = agt.agtStartDate.ToString("mm");
            txtEndD.Text = agt.agtEndDate.ToString("yyyy-MM-dd");
            ddlEndH.Text = agt.agtEndDate.ToString("HH");
            ddlEndT.Text = agt.agtEndDate.ToString("mm");
            city_id = agt.cityId;
            district_id = agt.districtId;
            store_id = agt.storeId;
        }
        store_data store = RepoService.getInstance().store_repo().doQueryOne(s => s.city_id == city_id && s.district_id == district_id && s.store_id == store_id);
        txtCity.Text = store.city;
        txtDistrict.Text = store.district;
        txtStore.Text = store.store;
    }
    public void BuildBtn()
    {
        string state = Request["state"];

        System.Web.UI.WebControls.Button btn = new System.Web.UI.WebControls.Button();
        btn.ID = "btnSubmit";
        btn.Text = "新增";
        btn.CommandName = "create";
        btn.Click += new EventHandler(btnSubmit_Click);

        if (state != null && state == "update")
        {
            btn.Text = "修改";
            btn.CommandName = "update";
        }
        
        plContainer.Controls.Add(btn);
    }
    public void addOption(ref DropDownList ddlType, int initVal, int limitVal, bool addZero)
    {
        ddlType.Items.Clear();
        while(initVal <= limitVal)
        {
            ddlType.Items.Add(new ListItem(formatOption(initVal, addZero)));
            initVal++;
        }
    }
    public string formatOption(int val, bool addZero)
    {
        string fVal = val.ToString();
        if (addZero)
        {
            if (fVal.Length == 1)
                return "0" + fVal;
        }
        return fVal;
    }
}