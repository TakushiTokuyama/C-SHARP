namespace SampleCode
{
    public abstract class SendMailBase
    {
        public Mail Mail { get; private set; } 

        /// <summary>
        /// 処理
        /// </summary>
        public void Execute() 
        {
            // 作成
            var mail = CreateMail();

            // 送信
            SendMail(mail);

            // 更新
            UpdateMail(mail);
        }

        protected abstract Mail CreateMail();

        protected abstract void SendMail(Mail mail);

        protected abstract void UpdateMail(Mail mail);


    }
}
