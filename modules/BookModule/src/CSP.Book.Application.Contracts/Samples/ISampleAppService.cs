using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CSP.Book.Samples;

public interface ISampleAppService : IApplicationService
{
	Task<ListResultDto<BookDto>> GetAsync();

	Task<ListResultDto<BookDto>> GetAuthorizedAsync();

	Tuple<string, string> GetQuoteOfTheDay();

	string GetAuthors();
}
