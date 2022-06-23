# Demo Notes

## Initial Build

- Create the new Razor Class Library under the SRC folder.
  - Add support for razor and views
- Delete all contents
- Add EPiServer.CMS @ 12.7.0
- Add a new empty controller (PluginLandingPage)

```C#
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
```

- Add Views/PluginLandingPage/Index.cshtml Folder and empty Razor file with hello world
- Add Views/Shared/_HappyHourLayout.cshtml
- Add Menu Folder
- Add a new Menu Provider
  - Implement ```IMenuProvider```
  - Decorate with ```[MenuProvider]```

```C#
using EPiServer.Shell.Navigation;

namespace MyNewPlugin.Menu;

[MenuProvider]
public class MyPluginMenuProvider : IMenuProvider
{
    public IEnumerable<MenuItem> GetMenuItems()
    {
        return  new List<MenuItem> 
        {
            new UrlMenuItem("Plugin Demo", "/global/cms/admin/happyhourplugin", "/PluginLandingPage/Index")
        };
    }
}

```

- Note that this does not yet have a menu!
- Update the layout page to render the menu

```HTML
@using EPiServer.Shell.Navigation
<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>@ViewBag.Title</title>
</head>
<body style="margin: 0;">
    @Html.CreatePlatformNavigationMenu()
    <div @Html.ApplyPlatformNavigation()>
        <div class="container-fluid" style="border-top: 1px solid #d6d6d6;">
            @RenderBody()
        </div>
    </div>
</body>
</html>
```

## Blue Peter Moment

- Add Nuget Packages
- Update Startup Configure Services

```C#
services.AddRobotsHandler();
services.AddCspManager();
```

- Update Startup Configure

```C#
app.UseCspManager();
```