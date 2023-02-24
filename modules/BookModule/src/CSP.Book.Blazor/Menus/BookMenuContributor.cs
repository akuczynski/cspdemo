using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace CSP.Book.Blazor.Menus;

public class BookMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        var bookMenuItem = new ApplicationMenuItem(BookMenus.Prefix, displayName: "Book", "/Book", icon: "fa fa-globe");

        //  when this menu item have to be visible only by the authenticated users then add call to RequireAuthenticated(); 
        context.Menu.AddItem(bookMenuItem);

        bookMenuItem.AddItem(new ApplicationMenuItem(
                "BookSubPage",
                "SubPage",
                url: "~/Book/SubPage"
            ).RequirePermissions("Book_Get_Author"));


        bookMenuItem.AddItem(new ApplicationMenuItem(
                "BookSubPage2",
                "SubPage2",
                url: "~/Book/SubPage2"
            ).RequirePermissions("Book_Get_Quote"));
         
        return Task.CompletedTask;
    }


    public Task<List<string>> GetList()
    {
        var list = new List<string>();

        return Task.FromResult(list); 
    }
}
