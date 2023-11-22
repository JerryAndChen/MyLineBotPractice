using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Sign_agentRecord : System.Web.UI.Page
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
    private void BindData()
    {
        using (var db = new LineServiceEntities())
        {
            var query = from a in db.agent_record
                        join b in db.user_data
                        on a.agtUserId equals b.userId
                        where a.agtId == id
                        select new
                        {
                            userName = b.userName,
                            sexType = b.sexType,
                            cityId = b.cityId,
                            districtId = b.districtId,
                            storeId = b.storeId,
                            phone = b.phone
                        };
            if(query.Count() == 0)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerText = "目前並未有支援人員";
                div.Attributes.Add("class", "center");
                Page.Controls.Add(div);
            }
            Repeater.DataSource = query.ToList();
            Repeater.DataBind();
        }
    }
}