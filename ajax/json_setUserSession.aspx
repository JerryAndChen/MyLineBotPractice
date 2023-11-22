<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="Newtonsoft.Json" %>
<script runat="server" lang="C#">
    protected void Page_Load(object sender, EventArgs e)
    {
        info info = new info();
        string userId = Request.Form["userId"];
        if(userId == null)
        {
            info.Pass = false;
            info.ErrorMsg = "無法取得使用者資訊";
        }
        else
        {
            Session["userId"] = userId;
            user_data user = GetUserData(userId);
            if(user == null)
            {
                info.Pass = true;
                info.Action = "register.aspx";
            }
            else
            {
                Session[WebConstants.Session_Current_User] = user;
                info.Pass = true;
                info.Action = "index.aspx";
            }
        }
        Response.Write(JsonConvert.SerializeObject(info));
    }
    private user_data GetUserData(string userId)
    {
        user_data_repo user_repo = new user_data_repo();
        user_data user = user_repo.doQueryOne(u => u.userId == userId);
        return user;
    }
    class info
    {
        bool pass;
        string errorMsg;
        string action;

        public bool Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
            }
        }

        public string ErrorMsg
        {
            get
            {
                return errorMsg;
            }

            set
            {
                errorMsg = value;
            }
        }

        public string Action
        {
            get
            {
                return action;
            }

            set
            {
                action = value;
            }
        }
    }
</script>
