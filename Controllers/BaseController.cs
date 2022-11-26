using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using onlineShop.Models;

namespace onlineShop.Controllers;

public abstract class BaseController : Controller
{
    public void notify(string message, string title ="Sketekete Online Ordering",NotificationType notificationType = NotificationType.success){
        var msg = new 
        {
            message = message,
            title = title,
            icon = notificationType.ToString(),
            type = notificationType.ToString(),
            provider ="sweetAlert"
        };
         TempData["Notify"] = JsonConvert.SerializeObject(msg);
    }
}
