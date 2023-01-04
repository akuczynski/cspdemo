using Volo.Abp.Reflection;

namespace CSP.Book.Permissions;

public class BookPermissions
{
    public const string GroupName = "Book";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(BookPermissions));
    }
}
