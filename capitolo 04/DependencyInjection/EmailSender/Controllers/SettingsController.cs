using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services;

namespace TestEmailSender.Controllers
{
    public class SettingsController : Controller
    {
        private readonly EmailSettings _settings;

        public SettingsController(IOptions<EmailSettings> settingsOptions)
        {
            _settings = settingsOptions.Value;
        }

        public IActionResult Index()
        {
            ViewData["Username"] = _settings.Username;
            ViewData["SmtpServer"] = _settings.SmtpServer;
            return View();
        }
    }
}
