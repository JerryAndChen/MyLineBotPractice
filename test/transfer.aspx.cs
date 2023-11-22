using System;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Collections.Generic;

public partial class test_transfer : System.Web.UI.Page
{
    SqlHelper _sqlHelper = new SqlHelper();
    SqlConnection _conn;
    string[] cityArr = new string[] { "台北市", "新北市", "基隆市", "桃園市", "新竹縣", "新竹市", "苗栗縣", "台中市", "南投縣", "彰化縣", "雲林縣", "嘉義縣", "嘉義市", "台南市", "高雄市", "屏東縣", "宜蘭縣", "花蓮縣", "台東縣", "澎湖縣", "金門縣", "連江縣" };
    string[] seq = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void btnTransfer_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button btn = sender as System.Web.UI.WebControls.Button;
        switch (btn.ID)
        {
            case "btnTransfer":
                string City = ddlCity.SelectedValue;
                City = City.Replace("臺", "台");
                doTransfer(City);
                Response.Write("<script>alert('轉換成功')</script>");
                break;
            case "btnBatchTransfer":
                foreach(string city in cityArr)
                {
                    doTransfer(city.Replace("臺", "台"));
                }
                Response.Write("<script>alert('轉換成功')</script>");
                break;
        }
    }

    private void doTransfer(string City)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        string data = readFileAsString(City);
        Store obj = JsonConvert.DeserializeObject<Store>(data);
        //int cityId = obj.City_id;
        string cityName = obj.City_name;
        string store, districtID, cityID, address;
        string storeID = "";
        string sql;
        cityID = "CT" + numberAddZero(obj.City_id);
        insertCityMap(cityID, cityName);
        for (int i = 0; i < obj.Stores.Length; i++)
        {
            store = obj.Stores[i].POIName;
            address = obj.Stores[i].Address;
            districtID = findDistrictName(cityID, address);
            if (districtID != "")
            {
                if (dic.ContainsKey(districtID))
                {
                    dic[districtID] = dic[districtID] + 1;
                }
                else
                {
                    dic[districtID] = 1;
                }
                storeID = "ST" + numberAddZero(dic[districtID]);
            }

            //Response.Write(district);
            using (_conn = _sqlHelper.GetConnection())
            {
                _conn.Open();
                sql = "insert into storedata(city_id, district_id, address, store, store_id)values(@cityId, @districtId, @address, @store, @storeId)";
                DynamicParameters _params = new DynamicParameters();
                _params.Add("@cityId", cityID);
                _params.Add("@districtId", districtID);
                _params.Add("@address", address);
                _params.Add("@store", store);
                _params.Add("@storeId", storeID);

                _conn.Execute(sql, _params);
            }
        }
        
    }

    private void insertCityMap(string cityId, string cityName)
    {
        string sql = "";
        string districtId = "";
        dynamic cityDetail = JsonConvert.DeserializeObject<DynamicDictionary>(readFileAsString("台灣各行政區列表"));

        //新增至區碼表 => 縣市
        using (_conn = _sqlHelper.GetConnection())
        {
            _conn.Open();
            sql = "insert into cityMap(code_id, code_name, code_level)values(@codeId, @codeName, @codeLevel)";
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@codeId", cityId);
            _params.Add("@codeName", cityName);
            _params.Add("@codeLevel", "1");

            _conn.Execute(sql, _params);
        }

        for (int i = 0; i < cityDetail[cityName].Count; i++)
        {

            //新增至區碼表 => 區
            using (_conn = _sqlHelper.GetConnection())
            {
                _conn.Open();
                districtId = "DT" + numberAddZero(i + 1);
                sql = "insert into cityMap(up_code_id, code_id, code_name, code_level)values(@upCodeId, @codeId, @codeName, @codeLevel)";
                DynamicParameters _params = new DynamicParameters();
                _params.Add("@upCodeId", cityId);
                _params.Add("@codeId", districtId);
                _params.Add("@codeName", (string)cityDetail[cityName][i]);
                _params.Add("@codeLevel", "2");

                _conn.Execute(sql, _params);
            }
        }
    }

    private string findDistrictName(string cityId, string address)
    {
        string returnStr = "";
        string sql = "";
        Dictionary<string, string> map;

        sql = "select code_id, code_name from cityMap where code_level='2' and up_code_id=@upCodeId";
        using (_conn = _sqlHelper.GetConnection())
        {
            _conn.Open();
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@upCodeId", cityId);
            var dictionary = _conn.Query(sql, _params).ToDictionary(d => (string)d.code_id, d => (string)d.code_name);
            map = dictionary;
        }
        foreach(var data in map)
        {
            string codeId = data.Key;
            string codeName = data.Value;
            if (address.Contains(codeName))
            {
                returnStr = codeId;
            }
        }
        return returnStr;
    }

    private string numberAddZero(int num)
    {
        string returnStr = num.ToString();
        if(returnStr.Length == 1)
        {
            returnStr = "00" + returnStr;
        }
        if(returnStr.Length == 2)
        {
            returnStr = "0" + returnStr;
        }
        return returnStr;
    }

    private string readFileAsString(string fileName)
    {
        string data = "";
        //do Transfer
        string path = @"D:\\Company\\Jerry.Chen\\Downloads\\convenience-store-data-master\\7-11\\"+fileName+".json";
        if (File.Exists(path))
        {
            using (StreamReader reader = File.OpenText(path))
            {
                string s;
                while ((s = reader.ReadLine()) != null)
                {
                    data += s;
                }
            }
        }
        return data;
    }

    class Store
    {
        private int _city_id;
        private string _city_name;
        private StoreDetails[] _stores;
        public Store()
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }

        public int City_id
        {
            get
            {
                return _city_id;
            }

            set
            {
                _city_id = value;
            }
        }

        public string City_name
        {
            get
            {
                return _city_name;
            }

            set
            {
                _city_name = value;
            }
        }

        public StoreDetails[] Stores
        {
            get
            {
                return _stores;
            }

            set
            {
                _stores = value;
            }
        }

        
    }
    class StoreDetails
    {
        private string _POIName;
        private string _Telno;
        private string _FaxNo;
        private string _Address;

        public string POIName
        {
            get
            {
                return _POIName;
            }

            set
            {
                _POIName = value;
            }
        }

        public string Telno
        {
            get
            {
                return _Telno;
            }

            set
            {
                _Telno = value;
            }
        }

        public string FaxNo
        {
            get
            {
                return _FaxNo;
            }

            set
            {
                _FaxNo = value;
            }
        }

        public string Address
        {
            get
            {
                return _Address;
            }

            set
            {
                _Address = value;
            }
        }
    }
}