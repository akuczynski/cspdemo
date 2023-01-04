using AutoMapper;

namespace CSP.Book;

public class BookApplicationAutoMapperProfile : Profile
{
    public BookApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Book, BookDto>();
	}
}
