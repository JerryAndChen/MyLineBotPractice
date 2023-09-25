<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Shared_Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="~/assets/css/main.css" rel="stylesheet">
        <style>
            input[type=button], .btnCal{
                color:black;
                background-color: transparent;
                border:0px;
            }
            td, th{
                text-align:center;
                padding:0px;
            }
            td.tdCalendar:hover{
                background-color: #FCFBBF;
            }
            #normal_display{
                position:absolute;
                top:50%;
                left:50%;
                transform:translate(-50%,-50%);
            }
        </style>
        <script>
            //var inputField = "<%=Request["field"]%>";    //對應要選擇日期的input
            var yearArr = [2020,2021,2022,2023,2024,2025];
            var monthArr = [1,2,3,4,5,6,7,8,9,10,11,12];
            var weekArr = [0,1,2,3,4,5,6];
            var monthObj = {1:13,2:14};
            var weekObj = [];   //存放當下選擇該月所屬日期
            var tempArr = [];   //存放每個日期所對應禮拜幾陣列
            var state = -1;
            var ckYear, ckMonth, ckDay;
            

            document.addEventListener("DOMContentLoaded",function(){
                initCurrentDate();
            });
            function initCurrentDate(){
                var date, month, year;
                date = new Date();
                year = date.getFullYear();
                month = monthArr[date.getMonth()];
                
                initBanner(year, month);
            }
            function initBanner(year, month){
                var day, i;

                day = getDay(year, month);

                for(i=1;i<=day;i++){
                    renderWeek(year, month, i);
                }
                // console.log(weekObj);
                renderCalendar();

                weekObj = [];
                tempArr = [];
                state = -1;
                
                form1.year.value = year;
                form1.month.value = month;

                ckYear = year;
                ckMonth = month;

                
            }
            function getDay(year, month){
                var isLeap = (year%4 == 0)
                if(year%100 == 0){
                    isLeap = (year%400 == 0);
                }
                switch(month){
                    case 4: case 6: case 9: case 11:
                        return 30;
                        break;
                    case 2:
                        return isLeap ? 29 : 28;
                        break;
                    default:
                        return 31;
                }

            }
            function renderWeek(year, month, day){
                var weekDay, trCalendars, trCalendar, i; 
                var weekDay = ZellerFunction(year, month, day);
                // console.log(weekDay);
                if(state==-1 || state==6){
                    tempArr = new Array("none","none","none","none","none","none","none");
                    weekObj.push(tempArr);
                }
                // let obj = new Object();
                // obj[weekDay] = day;
                tempArr[weekDay] = day;
                
                state = weekDay;
            }
            function renderCalendar(){
                var i, j, obj, trCalendar;
                for(i=0;i<weekObj.length;i++){
                    obj = weekObj[i];
                    trCalendar = document.createElement("tr");
                    trCalendar.setAttribute("class","trCalendar");
                    for(j=0;j<=6;j++){
                        let td = document.createElement("td");
                        td.setAttribute("class","tdCalendar");
                        if(obj[j]!="none"){
                            let btn = document.createElement("input");
                            btn.setAttribute("type","button");
                            btn.setAttribute("value", obj[j]);
                            btn.setAttribute("onclick","selectDate("+obj[j]+");");
                            td.appendChild(btn);
                        }
                        trCalendar.appendChild(td);
                    }
                    tbCalendar.appendChild(trCalendar);
                }
                
            }
            function chgMonth(obj){
                var trCalendar;
                if(obj.id=="next"){
                    ckYear = (ckMonth==12) ? ckYear+1 : ckYear;
                    ckMonth = (ckMonth==12) ? 1 : ckMonth+1;
                }else if(obj.id=="previous"){
                    ckYear = (ckMonth==1) ? ckYear-1 : ckYear;
                    ckMonth = (ckMonth==1) ? 12 : ckMonth-1;
                }
                document.querySelectorAll(".trCalendar").forEach(e => e.remove());
                initBanner(ckYear,ckMonth,);
            }
            function ZellerFunction(year, month, day){
                var y, c, m, d, w;
                m = monthObj[month] ? monthObj[month] : month;
                year = m>12 ? year-1 : year;
                y = Number(year.toString().substring(2));
                c = Number(year.toString().substring(0,2));
                d = day;
                w = (y + Math.floor(y/4) + Math.floor(c/4) - (2*c) + Math.floor((26*(m+1))/10) + d - 1) % 7;
                w = (w%7+7)%7;
                return w;
            }
            function selectDate(selectDay){
                var selectedDate = ckYear.toString()+"-"+dateAddZero(ckMonth.toString())+"-"+dateAddZero(selectDay.toString());
                window.parent.selectDate(selectedDate);
            }
            function dateAddZero(obj){
                return (obj.length < 2) ? "0"+obj : obj;
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="normal_display">
                <table id="tbCalendar" width="250px">
                    <tr>
                        <td colspan="7">
                            <div align="center">
                                <input class="btnCal" id="previous" type="button" value="<<" onclick="chgMonth(this)">
                                <input class="btnCal" id="year" type="button">
                                <input class="btnCal" id="month" type="button">
                                <input class="btnCal" id="next" type="button" value=">>" onclick="chgMonth(this)">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>日</th>
                        <th>一</th>
                        <th>二</th>
                        <th>三</th>
                        <th>四</th>
                        <th>五</th>
                        <th>六</th>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>
