using System;

namespace SampleCode
{
    public class TestMail : SendMailBase
    {
        public TestMail() 
        {
            base.Execute();
        }

        protected override Mail CreateMail()
        {
            return new Mail()
            {
                Body = "Hello",
                Subject = "World"
            };
        }

        protected override void SendMail(Mail mail)
        {
            Console.WriteLine($"件名：{mail.Subject}  本文：{mail.Body}を送信しました");
        }

        protected override void UpdateMail(Mail mail)
        {
            Console.WriteLine($"件名：{mail.Subject} 本文：{mail.Body}を更新しました");
        }
    }
}
