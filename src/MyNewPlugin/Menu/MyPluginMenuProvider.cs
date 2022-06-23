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
