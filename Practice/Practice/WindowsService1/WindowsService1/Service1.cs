using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        static bool th = false;

        static string HeavyMethod()
        {
            Console.WriteLine("1");
            Thread.Sleep(6000);
            if (th)
            {
                Console.WriteLine("2");
            }

            return "3";
        }


        Service1() 
        {
            InitializeComponent();
        }

        static void Main(string[] args)
        {
#if DEBUG
            Service1 se = new Service1();

            se.OnStart(null);

#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);

#endif
        }

        protected override void OnStart(string[] args)
        {
            string result = "";

            Thread thread = new Thread(new ThreadStart(() =>
            {
                result = HeavyMethod();
            }));

            thread.Start();

            OnStop();

            thread.Join(10000);

            Console.WriteLine(result);

            Console.ReadLine();
        }

        protected override void OnStop()
        {
            th = true;
        }
    }
}
