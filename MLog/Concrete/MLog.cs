using MLog.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Text;

namespace MLog.Concrete
{
    public class MLog : IMLog
    {
        private string fileName;
        private string fileFullPath;
        private string currentPath;
        private string dir;
        public MLog()
        {
            fileName =$"{DateTime.Now.ToString("dd.MM.yyyy")}.txt";
            currentPath = AppDomain.CurrentDomain.BaseDirectory;

            dir = $@"{currentPath}Mlogs";
            fileFullPath = $@"{dir}\{fileName}";


            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(fileFullPath))
            {
                File.Create(fileFullPath);
            }
        }
        public void Info(string message)
        {
            StreamWriter sw = new StreamWriter(fileFullPath);
            string methodName=MethodBase.GetCurrentMethod().Name;

            string log = $"{DateTime.Now:dd.MM.yyyy HH:mm} | {methodName}";

            sw.WriteLine(log);
                     
            sw.Close();
        }
    }
}
