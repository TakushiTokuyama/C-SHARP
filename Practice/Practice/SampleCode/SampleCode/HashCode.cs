using System;
using System.Security.Cryptography;
using System.Text;

namespace SampleCode
{
    public class HashCode
    {
        public string HashConvert(string password) 
        {
            // 文字コードを指定して、文字列からバイナリへの変換を行う。
            byte[] bytes = Encoding.ASCII.GetBytes(password);

            // バイナリからハッシュへと変換を行う。
            var hash = SHA512.Create().ComputeHash(bytes) ;
       
            return ByteArrayToString(hash);

            
        }

        static string ByteArrayToString(byte[] arrInput) 
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++) 
            {
                // ハッシュから16進数に変換する。
                sOutput.Append(arrInput[i].ToString("D4"));
            }
            return sOutput.ToString();
        }

        static void Execute() 
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
