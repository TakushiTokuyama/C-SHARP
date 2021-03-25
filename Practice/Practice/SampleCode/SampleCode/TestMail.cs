using System;

namespace SampleCode
{
    public class TestMail : SendMailBase
    {
        private User user;

        public TestMail(User user)
        {
            this.user = user;
            Execute();
        }

        protected override Mail CreateMail()
        {
            return new Mail()
            {
                Subject = $"{user.Token}",
                Body = $"{user.Name }さん",
            };
        }

        protected override void Execute()
        {
            // 作成
            var mail = CreateMail();

            // 送信
            SendMail(mail);

            // 更新
            UpdateMail(mail);
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
