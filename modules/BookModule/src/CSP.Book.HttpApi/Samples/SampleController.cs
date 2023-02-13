using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace CSP.Book.Samples;

[Area(BookRemoteServiceConsts.ModuleName)]
[RemoteService(Name = BookRemoteServiceConsts.RemoteServiceName)]
[Route("api/book")]
public class SampleController : BookController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

    public SampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }


	[HttpGet]
    public async Task<ListResultDto<BookDto>> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<ListResultDto<BookDto>> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Authorize("Book_Get_Author")]
    [Route("authors")]
	public string GetAuthorOfTheDay()
	{
		return _sampleAppService.GetAuthorOfTheDay();
	}

	[HttpGet]
	[Authorize]
	[Route("quote")]
	public string GetQuoteOfTheDay()
	{
        return _sampleAppService.GetQuoteOfTheDay();
	}
}
