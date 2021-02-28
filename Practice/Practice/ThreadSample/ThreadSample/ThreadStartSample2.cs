using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class ThreadStartSample2
    {
        /// <summary>
        /// 例外失敗
        /// </summary>
        public static void ExcuteFiler() 
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Greet));
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.WriteLine("終了");
            }
        }

        /// <summary>
        /// 例外成功
        /// </summary>
        public static void Excute() 
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    Greet();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
            thread.Start();
        }

        /// <summary>
        /// 挨拶
        /// </summary>
        public static void Greet()
        {
            try
            {
                string str = "a";
                int.Parse(str);
                Console.WriteLine("Hello");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
