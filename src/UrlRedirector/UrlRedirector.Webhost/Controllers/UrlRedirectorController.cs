using Microsoft.AspNetCore.Mvc;
using Volkin.UrlRedirector.Application.UseCases.GenerateUrl;
using Volkin.UrlRedirector.Webhost.Contracts.Responses;

namespace Volkin.UrlRedirector.Webhost.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UrlRedirectorController : MediatRControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<GenerateUrlResponse>> GenerateUrl(string id, CancellationToken ct)
        {
            GetRedirectUrlResult getRedirectUrlResult = await Send(new GetRedirectUrlCommand { ShortUrl = id }, ct);

            if (String.IsNullOrWhiteSpace(getRedirectUrlResult.Url))
                return NotFound();

            return Redirect(getRedirectUrlResult.Url);
        }
    }
}