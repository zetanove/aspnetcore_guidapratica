namespace Services
{
    public interface IEmailSender
    {
        public void Send(string email, string subject, string body);
    }

    public class EmailSender: IEmailSender
    {
        public void Send(string email, string subject, string body)
        {
           
            Console.WriteLine($"subject: {subject}, body: {body}, inviata a {email}");
        }
    }

    public class EmailSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
    }
}
