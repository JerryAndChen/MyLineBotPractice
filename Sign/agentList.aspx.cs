using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Sign_agentList : System.Web.UI.Page
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
    //protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string id = Repeater.SelectedRow.Cells[0].Text;
    //    Response.Redirect("agentApply.aspx?id=" + id);
    //}
    protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;

            HiddenField hfCity = item.FindControl("hfCity") as HiddenField;
            HiddenField hfDistrict = item.FindControl("hfDistrict") as HiddenField;
            Label lbStore = item.FindControl("lbStore") as Label;
            lbStore.Text = RepoService.getInstance().store_repo().doQueryOne(s => s.city_id==hfCity.Value && s.district_id==hfDistrict.Value && s.store_id == lbStore.Text).store;

            Label lbRole = item.FindControl("lbRole") as Label;
            lbRole.Text = lbRole.Text == "1" ? "店長" : "員工";
        }
    }
    protected void Repeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        RepeaterItem item = e.Item;
        string id = (item.FindControl("hfID") as HiddenField).Value;
        Response.Redirect("agentApply.aspx?id=" + id);
    }
    public void BindData()
    {
        List<agent_data> list = RepoService.getInstance().agt_data_repo().doQueryAll(a => a.cityId == user.cityId && a.districtId == user.districtId && a.agtStartDate>=DateTime.Now);
        if(list.Count == 0)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.InnerText = "本區各門市尚未有需代理職務";
            div.Attributes.Add("class", "center");
            Page.Controls.Add(div);
        }
        else
        {
            Repeater.DataSource = list;
            Repeater.DataBind();
        }
    }
}