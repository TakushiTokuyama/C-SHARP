namespace SampleCode
{
    public abstract class SendMailBase
    {
        public Mail Mail { get; private set; }

        /// <summary>
        /// 処理
        /// </summary>
        protected abstract void Execute();

        protected abstract Mail CreateMail();

        protected abstract void SendMail(Mail mail);

        protected abstract void UpdateMail(Mail mail);


    }
}
