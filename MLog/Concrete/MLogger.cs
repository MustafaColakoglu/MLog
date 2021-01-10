using MLog.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace MLog.Concrete
{
    public class MLogger : IMLogger
    {
        private string fileName;
        private string fileFullPath;
        private string currentPath;
        private string dir;
        public MLogger()
        {
            fileName =$"{DateTime.Now:dd.MM.yyyy}.txt";
            currentPath = AppDomain.CurrentDomain.BaseDirectory;

            dir = $@"{currentPath}Mlogs";
            fileFullPath = $@"{dir}\{fileName}";


            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(fileFullPath))
            {
                File.Create(fileFullPath).Close();
               
            }
        }
        public void Info(string message)
        {
            StackTrace stackTrace = new StackTrace();

            string str = $"{DateTime.Now:dd.MM.yyyy HH:mm} | {stackTrace.GetFrame(1).GetMethod().DeclaringType.Name} | {stackTrace.GetFrame(1).GetMethod().Name} | {message} \n";

           

            using (StreamWriter streamWriter = File.AppendText(this.fileFullPath))
                streamWriter.WriteLine(str);

            
        }

        public void Info(Exception ex)
        {
            StackTrace stackTrace = new StackTrace();

            string str = $"{DateTime.Now:dd.MM.yyyy HH:mm} | {stackTrace.GetFrame(1).GetMethod().DeclaringType.Name} | {stackTrace.GetFrame(1).GetMethod().Name} | {ex.Message} | {ex.InnerException} | {ex.StackTrace} \n";

          

            using (StreamWriter streamWriter = File.AppendText(this.fileFullPath))
                streamWriter.WriteLine(str);
        }
    }
}
