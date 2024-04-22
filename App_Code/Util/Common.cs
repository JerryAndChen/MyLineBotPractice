using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Util
{
    /// <summary>
    /// Util 的摘要描述
    /// </summary>
    public class Common
    {
        public static object get(object value)
        {
            return value ?? DBNull.Value;
        }
        public static int parseInt(string value)
        {
            int result;
            if(int.TryParse(value,out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
        public static DateTime formatDateTime(string date, string hour, string time)
        {
            string dateTime = date + " " + hour + ":" + time;
            return DateTime.Parse(dateTime);
        }
        public static void sendMail()
        {
            System.Web.HttpContext.Current.Response.BufferOutput = false;
            try
            {
                System.Net.NetworkCredential credential = new System.Net.NetworkCredential("jerryamo0816@gmail.com", "vnrutvzjhrtnvvmb");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage("system@HelpSeeker.mail.com", "Jerry.Chen@e21mm.com");
                message.Subject = "title - jerryTest";
                message.Body = "this is a test";
                smtp.EnableSsl = true;
                smtp.Credentials = credential;
                smtp.Send(message);
            }
            catch (Exception e)
            {
                Util.Log.LogToFile("send email failed", e.Message);
            }
            
        }
        public static string getAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static void sendMail(string receiver, string subject, string body, bool isHTML)
        {
            try
            {
                string mail_Server = getAppSetting("mail_Server");
                int mail_Port = parseInt(getAppSetting("mail_Port"));
                string mail_User = getAppSetting("mail_User");
                string mail_Pswd = getAppSetting("mail_Pswd");
                System.Net.NetworkCredential credential = new System.Net.NetworkCredential(mail_User, mail_Pswd);
                SmtpClient smtp = new SmtpClient(mail_Server, mail_Port);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("system@HelpSeeker.mail.com");
                message.To.Add(new MailAddress(receiver));
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHTML;
                //string completeMsg = "complete";
                smtp.EnableSsl = true;
                smtp.Credentials = credential;
                //string done = "ok";
                //smtp.SendAsync(message, done);
                smtp.Send(message);
            }
            catch (Exception e)
            {
                Util.Log.LogToFile("send email failed", e.Message);
            }

        }
    }
}
