using Microsoft.AspNetCore.Mvc;
using Services;

namespace TestEmailSender.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender sender)
        {
            _emailSender = sender;
        }

        public IActionResult Send()
        {
            //EmailSender sender=new EmailSender();  
            //sender.Send("email@test.it", "subject", "body");

            _emailSender.Send("email@test.it", "subject", "body");

            return View();
        }

        public IActionResult Send2([FromServices] IEmailSender sender)
        {
            sender.Send("email@test.it", "subject", "body");

            return View("Send");
        }

        public IActionResult Send3()
        {
            var settings = HttpContext.RequestServices.GetService(typeof(EmailSettings));

            _emailSender.Send("email@test.it", "subject", "body");

            return View("Send");
        }

        public IActionResult Send4(string email, string subject, string body, bool debug)
        {
            _emailSender.Send(email, subject,body);

            if(debug)
                Console.WriteLine("email sent");

            return View("Send");
        }
    }
}
