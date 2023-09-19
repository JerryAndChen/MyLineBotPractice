using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Util
{
    /// <summary>
    /// Log 的摘要描述
    /// </summary>
    public class Log
    {
        public Log()
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }
        public static void LogToFile(string title, string content)
        {
            string filePath = "D:\\Personal\\jerry\\log.txt";
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(title + ":" + content + "\n");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.Write(title + ":" + content + "\n");
                }
            }
        }
    }
}
