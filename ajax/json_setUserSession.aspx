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
            info.Pass = true;
            info.ErrorMsg = "取得使用者資訊";
        }
        Response.Write(JsonConvert.SerializeObject(info));
    }
    class info
    {
        bool pass;
        string errorMsg;

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
    }
</script>
