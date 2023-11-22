using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Sign_helperList : System.Web.UI.Page
{
    CityMapRepo cityMapRepo;
    StoreDataRepo storeDataRepo;
    user_data user;
    protected void Page_Load(object sender, EventArgs e)
    {
        user = Master.user;
        if (!IsPostBack)
        {
            setCitySelect();
            setDistrictSelect();
            setStoreSelect();
            BindData();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindData();
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

            //Label lbRole = item.FindControl("lbRole") as Label;
            //lbRole.Text = lbRole.Text == "1" ? "店長" : "員工";
        }
    }
    protected void Repeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        RepeaterItem item = e.Item;
        string id = (item.FindControl("hfID") as HiddenField).Value;
        string email = (item.FindControl("lbEmail") as Label).Text;
        System.Web.UI.WebControls.Button btn = item.FindControl("btnInvite") as System.Web.UI.WebControls.Button;
        btn.Enabled = false;
        //寄送email
        store_data store = RepoService.getInstance().store_repo().doQueryOne(s => s.city_id == user.cityId && s.district_id == user.districtId && s.store_id == user.storeId);
        string subject = "支援需求邀請";
        string body = "您有來自<br>"+store.city+store.district+store.store+"<br>的人力支援邀請";
        Util.Common.sendMail(email, subject, body, true);
        ClientScript.RegisterStartupScript(typeof(Page), "registerSuccessful", "showMsg(\"已成功送出邀請\")", true);
    }
    public void BindData()
    {
        //List<agent_data> list = RepoService.getInstance().agt_data_repo().doQueryAll(a => a.dcsnNo==null);
        List<user_data> list = RepoService.getInstance().user_repo().doQueryAll(a => a.cityId == ddlCity.SelectedValue && a.districtId == ddlDistrict.SelectedValue && a.storeId == ddlStore.SelectedValue);
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
            
        }
        Repeater.DataBind();
    }

    private void setCitySelect()
    {
        ddlCity.Items.Clear();
        cityMapRepo = new CityMapRepo();
        Dictionary<string, string> map = cityMapRepo.GetCity();
        foreach (var data in map)
        {
            ddlCity.Items.Add(new ListItem(data.Value, data.Key));
        }
    }
    private void setDistrictSelect()
    {
        ddlDistrict.Items.Clear();
        cityMapRepo = new CityMapRepo();
        Dictionary<string, string> map = cityMapRepo.GetDistrict(ddlCity.SelectedValue);
        foreach (var data in map)
        {
            ddlDistrict.Items.Add(new ListItem(data.Value, data.Key));
        }
    }
    private void setStoreSelect()
    {
        ddlStore.Items.Clear();
        storeDataRepo = new StoreDataRepo();
        Dictionary<string, string> map = storeDataRepo.GetStore(ddlCity.SelectedValue, ddlDistrict.SelectedValue);
        foreach (var data in map)
        {
            ddlStore.Items.Add(new ListItem(data.Value, data.Key));
        }
        //txtAddress.Text = map[ddlStore.SelectedValue];
    }
    public void ddlStore_Change(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        switch (ddl.ID)
        {
            case "ddlCity":
                setDistrictSelect();
                setStoreSelect();
                break;
            case "ddlDistrict":
                setStoreSelect();
                break;
        }
    }
}