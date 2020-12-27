using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CountService
{
    public partial class LoginRecordService : ServiceBase
    {
        public LoginRecordService()
        {
            InitializeComponent();

            ServiceController sc = new ServiceController("LoginRecordService",".");
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                OnShutdown();
            }
            else
            {
                OnStart(null);
            }
        }
        public void Stop() 
        {
        }

        protected override void OnShutdown() 
        {
            // ファイルパス
            string path = @"C:\DateRecord\record.txt";
            // FileInfoのインスタンスを生成する
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Directory.Exists)
            {
                // フォルダーが存在しない場合は作成
                fileInfo.Directory.Create();
            }

            Encoding enc = Encoding.GetEncoding("Shift_JIS");

            StreamWriter writer = new StreamWriter(@"C:\DateRecord\record.txt", true, enc);

            // テキストを書き込む
            writer.WriteLine("ログアウト:" + DateTime.Now);

            writer.Close();
        }

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new LoginRecordService()
            };
            ServiceBase.Run(ServicesToRun);

            
        }
        protected override void OnStart(string[] args)
        {
            // ファイルパス
            string path = @"C:\DateRecord\record.txt";
            // FileInfoのインスタンスを生成する
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Directory.Exists)
            {
                // フォルダーが存在しない場合は作成
                fileInfo.Directory.Create();
            }

            Encoding enc = Encoding.GetEncoding("Shift_JIS");

            StreamWriter writer = new StreamWriter(@"C:\DateRecord\record.txt", true, enc);

            // テキストを書き込む
            writer.WriteLine("ログイン:" + DateTime.Now);

            writer.Close();
        }

        protected override void OnStop()
        {
        }
    }
}
