namespace TestMail
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "smtp.gmail.com";

            var port = 465;

            using (var smtp = new MailKit.Net.Smtp.SmtpClient()) 
            {
                smtp.Connect(host, port, MailKit.Security.SecureSocketOptions.SslOnConnect);

                smtp.Authenticate("sokoninoruna1520@gmail.com", "xvgpmmfhmkzbboqi");

                var mail = new MimeKit.MimeMessage();
                var builder = new MimeKit.BodyBuilder();
                mail.From.Add(new MimeKit.MailboxAddress("", "sokoninoruna1520@gmail.com"));
                mail.To.Add(new MimeKit.MailboxAddress("", "sokoninoruna@gmail.com"));
                mail.Subject = "";
                builder.TextBody = "";
                mail.Body = builder.ToMessageBody();

                smtp.Send(mail);

                smtp.Disconnect(true);
            }

            



        }
    }
}
