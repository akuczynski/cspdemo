using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace CSP.Book.Samples;

public class SampleAppService : BookAppService, ISampleAppService
{
	private IRepository<Book, long> _bookRepository;

	private readonly IObjectMapper<BookApplicationModule> _objectMapper;

	public SampleAppService(IRepository<Book, long> bookRepository,  
                            IObjectMapper<BookApplicationModule> objectMapper)
    {
		_bookRepository = bookRepository;
		_objectMapper = objectMapper;
	}

    public async Task<ListResultDto<BookDto>> GetAsync()
    {
        var books = await _bookRepository.GetListAsync();
		List<BookDto> bookDtos = _objectMapper.Map<List<Book>, List<BookDto>>(books);

		return new ListResultDto<BookDto>(bookDtos);
	}

    [Authorize]
    public async Task<ListResultDto<BookDto>> GetAuthorizedAsync()
    {
		return await GetAsync();
	}
}
