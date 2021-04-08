using SampleCode;
using System;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var password = new HashCode().HashConvert("1");

            var password2 = new HashCode().HashConvert(password);

            Console.WriteLine(password);

            if (password2 == "A0E65FEADC0BAE63AE088C3D8D648C3BBE145442E1D399618404042EE6785495DFA95844AB23CBE082A33467A96A50544DD42329CA55ADA7DF9E8CE7E0D1C740")
            {
                Console.WriteLine("ログイン成功");
            }
            else 
            {
                Console.WriteLine("ログイン失敗");
            }

            int byteCount = Encoding.GetEncoding("UTF-8").GetByteCount(password);

            Console.WriteLine(byteCount);
        }
    }
}
