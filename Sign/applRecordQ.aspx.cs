using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Sign_applRecordQ : System.Web.UI.Page
{
    user_data user;
    protected void Page_Load(object sender, EventArgs e)
    {
        user = Master.user;
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;

            HiddenField hfCity = item.FindControl("hfCity") as HiddenField;
            HiddenField hfDistrict = item.FindControl("hfDistrict") as HiddenField;
            Label lbStore = item.FindControl("lbStore") as Label;
            lbStore.Text = RepoService.getInstance().store_repo().doQueryOne(s => s.city_id == hfCity.Value && s.district_id == hfDistrict.Value && s.store_id == lbStore.Text).store;

            Label lbRole = item.FindControl("lbRole") as Label;
            lbRole.Text = lbRole.Text == "1" ? "店長" : "員工";
        }
    }
    protected void Repeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        RepeaterItem item = e.Item;
        string id = (item.FindControl("hfID") as HiddenField).Value;
        switch (e.CommandName)
        {
            case "update":
                //修改資料
                Response.Redirect("agentForm.aspx?id=" + id+ "&dcsnNo="+user.userId+"&state=update");
                break;
            case "viewDetail":
                //查看申請狀態
                Response.Redirect("applRecord.aspx?id=" + id);
                break;
            case "chkSupport":
                //查看支援人員
                Response.Redirect("agentRecord.aspx?id=" + id);
                break;
        }
        
    }
    protected void rptPage_ItemCommand(object sender, EventArgs e)
    {
        //BindPageIndex();
    }
    public void BindData()
    {
        List<agent_data> list = RepoService.getInstance().agt_data_repo().doQueryAll(a => a.dcsnNo==user.userId);
        if (list.Count == 0)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.InnerText = "查無資料";
            div.Attributes.Add("class", "center");
            Page.Controls.Add(div);
        }
        else
        {
            var json = JsonConvert.SerializeObject(list);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
            Repeater.DataSource = ucPage.BindPageInfo(dt);
            Repeater.DataBind();
        }
    }
}