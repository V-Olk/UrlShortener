using Microsoft.AspNetCore.Mvc;
using Volkin.UrlRedirector.Application.UseCases.GenerateUrl;
using Volkin.UrlRedirector.Webhost.Contracts.Responses;

namespace Volkin.UrlRedirector.Webhost.Controllers
{
    [ApiController]
    public class UrlRedirectorController : MediatRControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<GenerateUrlResponse>> Redirect(string id, CancellationToken ct)
        {
            GetRedirectUrlResult? getRedirectUrlResult = await Send(new GetRedirectUrlCommand { ShortUrl = id }, ct);

            return getRedirectUrlResult is null ?  NotFound() : Redirect(getRedirectUrlResult.Url!);
        }
    }
}