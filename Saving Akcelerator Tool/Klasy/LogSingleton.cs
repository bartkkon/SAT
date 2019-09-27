using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Saving_Accelerator_Tool
{
    public class LogSingleton
    {
        private static LogSingleton instance;
        private static object syncRoot = new Object();

        private string filename;
        private string path;

        private LogSingleton()
        {
            //filename = "SAT_Log_"+ DateTime.Now.Year.ToString()+"_"+ DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_"+ DateTime.Now.Minute.ToString() + "_"+ DateTime.Now.Second.ToString()+ "_" + Environment.UserName.ToString()+ ".txt";
            filename = "SAT_Log.txt";
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        public void SaveLog(string msg)
        {
            writeToFile(msg);
        }
        private void writeToFile(string msg)
        {
            lock (syncRoot)
            {
                using (StreamWriter writer = File.AppendText(path + "\\" + filename))
                {
                    writer.WriteLine("");
                    writer.WriteLine(DateTime.Now.ToString() + ": " + msg);

                    writer.Flush();
                    writer.Close();
                }
            }
        }
        public static LogSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new LogSingleton();
                    }
                }
                return instance;
            }
        }

    }
}
