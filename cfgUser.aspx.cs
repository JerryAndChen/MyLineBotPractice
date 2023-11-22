using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cfgUser : System.Web.UI.Page
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
            FillUserInfo();
        }
    }
    private void FillUserInfo() {
        user_data userInfo = RepoService.getInstance().user_repo().doQueryOne(u => u.userId == user.userId);
        txtName.Text = userInfo.userName;
        rdSexType.SelectedValue = userInfo.sexType;
        txtBirth.Text = userInfo.birth.ToString("yyyy-MM-dd");
        txtPhone.Text = userInfo.phone;
        txtEmail.Text = userInfo.email;
        ddlRole.SelectedValue = userInfo.roleId;
        ddlCity.SelectedValue = userInfo.cityId;
        ddlDistrict.SelectedValue = userInfo.districtId;
        ddlStore.SelectedValue = userInfo.storeId;
    }
    public void btnSubmit_Click(object sender, EventArgs e)
    {
        //Page.Validate();
        if (Page.IsValid)
        {
            if (doUpdate())
            {
                ClientScript.RegisterStartupScript(typeof(Page), "updateSuccess", "showMsg(\"修改成功\");", true);
            }
        }
    }
    public bool doUpdate()
    {
        user_data userInfo = RepoService.getInstance().user_repo().doQueryOne(u => u.userId == user.userId);
        userInfo.userName = txtName.Text;
        userInfo.sexType = rdSexType.SelectedValue;
        userInfo.phone = txtPhone.Text;
        userInfo.email = txtEmail.Text;
        userInfo.birth = DateTime.Parse(txtBirth.Text);
        userInfo.roleId = ddlRole.SelectedValue;
        userInfo.cityId = ddlCity.SelectedValue;
        userInfo.districtId = ddlDistrict.SelectedValue;
        userInfo.storeId = ddlStore.SelectedValue;
        try
        {
            RepoService.getInstance().user_repo().doUpdate(userInfo);
        }
        catch (Exception e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "updateFailed", "showMsg(\"修改失敗\");", true);
            Util.Log.LogToFile("update user_data failed", e.Message);
            return false;
        }

        return true;
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