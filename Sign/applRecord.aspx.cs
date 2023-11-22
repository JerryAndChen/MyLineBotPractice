using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Sign_applRecord : System.Web.UI.Page
{
    user_data user;
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        user = Master.user;
        id = Util.Common.parseInt(Request["id"]);
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

            Label lbSexType = item.FindControl("lbSexType") as Label;
            lbSexType.Text = lbSexType.Text == "1" ? "男" : "女";
        }
    }
    protected void Repeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        RepeaterItem item = e.Item;
        int id = Util.Common.parseInt((item.FindControl("hfId") as HiddenField).Value);
        int agtId = Util.Common.parseInt((item.FindControl("hfAgtId") as HiddenField).Value);
        string applNo = (item.FindControl("hfApplNo") as HiddenField).Value;
        if (e.CommandName == "approve")
            btnApprove_Click(id, agtId, applNo);
        else if(e.CommandName == "reject")
            btnReject_Click(id, applNo);
    }
    private void BindData()
    {
        using (var db = new LineServiceEntities())
        {
            var query = from a in db.agent_apply
                        join b in db.user_data
                        on a.applNo equals b.userId
                        where a.agtId == id && string.IsNullOrEmpty(a.isApprove)
                        select new {
                            userName = b.userName,
                            sexType = b.sexType,
                            cityId = b.cityId,
                            districtId = b.districtId,
                            storeId = b.storeId,
                            phone = b.phone,
                            id = a.id,
                            agtId = a.agtId,
                            applNo = a.applNo,
                            agtApplTime = a.applTime
                        };
            if(query.Count() == 0)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerText = "目前並未有申請人員";
                div.Attributes.Add("class", "center");
                Page.Controls.Add(div);
            }

            Repeater.DataSource = query.ToList();
            Repeater.DataBind();

        }
    }
    protected void btnApprove_Click(int id, int agtId, string applNo)
    {
        //apply is approved, write to agent_record, update agent_apply isApprove to Y
        agent_apply applInfo = RepoService.getInstance().agt_apply_repo().doQueryOne(a => a.id == id && a.applNo == applNo);
        applInfo.isApprove = "Y";
        RepoService.getInstance().agt_apply_repo().doUpdate(applInfo);

        agent_record agtRec = new agent_record();
        agtRec.agtId = agtId;
        agtRec.agtUserId = applNo;
        RepoService.getInstance().agt_record_repo().doCreate(agtRec);

        BindData();
    }
    protected void btnReject_Click(int id, string applNo)
    {
        //apply is rejected, update agent_apply isApprove to N
        agent_apply applInfo = RepoService.getInstance().agt_apply_repo().doQueryOne(a => a.id == id && a.applNo == applNo);
        applInfo.isApprove = "N";
        RepoService.getInstance().agt_apply_repo().doUpdate(applInfo);
        BindData();
    }
}