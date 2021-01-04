using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadSample thread = new ThreadSample();

            //thread.Excute();

            //TaskSample task = new TaskSample();

            //task.Excute();

#if DEBUG
            Console.WriteLine("debug");
#else

#endif
            AwaitAsyncSample awaitAsyncSample = new AwaitAsyncSample();

            awaitAsyncSample.SampleAsync();

            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            FileInfo fileInfo = new FileInfo(path);

            string settingFile = fileInfo + "\\Settings.xml";

            DataSet dataSet = new DataSet();

            dataSet.ReadXml(settingFile);

            DataTable table = dataSet.Tables[0];

            for (int i = 0; i < table.Rows.Count; i++) 
            {
                Console.WriteLine(table.Rows[i][0]);
            }

            // awaitAsyncSample.Excute();
        }
    }
}
