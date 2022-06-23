namespace MyNewPlugin.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "WebAdmins, WebEditors")]
public class PluginLandingPageController : Controller
{
    [HttpGet]
    [Route("[controller]/[action]")]
    public IActionResult Index()
    {
        return View();
    }
}
