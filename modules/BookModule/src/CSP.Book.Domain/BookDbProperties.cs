namespace CSP.Book;

public static class BookDbProperties
{
    public static string DbTablePrefix { get; set; } = "Book";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Book";
}
