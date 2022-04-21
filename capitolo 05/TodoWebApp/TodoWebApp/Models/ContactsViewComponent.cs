using Microsoft.AspNetCore.Mvc;

namespace TodoWebApp.Models
{
    public class ContactsViewComponent : ViewComponent
    {
        public ContactsViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync(string email, string tel)
        {
            Contact contact = new Contact() { Email = email, Tel = tel};
            return await Task.FromResult((IViewComponentResult)View("Contacts", contact));
        }

    }


}
