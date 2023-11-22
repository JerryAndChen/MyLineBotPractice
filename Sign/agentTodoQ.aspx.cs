using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Sign_agentTodoQ : System.Web.UI.Page
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
    private void BindData()
    {
        using (var db = new LineServiceEntities())
        {
            var query = from a in db.agent_record
                        join b in db.agent_data
                        on a.agtId equals b.id
                        where a.agtUserId == user.userId && b.agtStartDate >= DateTime.Now
                        orderby b.agtStartDate
                        select new
                        {
                            title = b.title,
                            cityId = b.cityId,
                            districtId = b.districtId,
                            storeId = b.storeId,
                            roleId = b.roleId,
                            agtStartDate = b.agtStartDate,
                            agtEndDate = b.agtEndDate
                        };
            if (query.Count() == 0)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerText = "目前並未有需要的支援";
                div.Attributes.Add("class", "center");
                Page.Controls.Add(div);
            }
            Repeater.DataSource = query.ToList();
            Repeater.DataBind();
        }
    }
}