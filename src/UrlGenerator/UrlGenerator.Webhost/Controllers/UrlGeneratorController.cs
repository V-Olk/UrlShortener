using Microsoft.AspNetCore.Mvc;
using Volkin.UrlGenerator.Application.UseCases.GenerateUrl;
using Volkin.UrlGenerator.Webhost.Contracts.Requests;
using Volkin.UrlGenerator.Webhost.Contracts.Responses;

namespace Volkin.UrlGenerator.Webhost.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UrlGeneratorController : MediatRControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GenerateUrlResponse>> GenerateUrl(GenerateUrlRequest request, CancellationToken ct)
        {
            GenerateUrlResult generateUrlResult = await Send(new GenerateUrlCommand { Url = request.Url }, ct);

            return Created(String.Empty, new { generateUrlResult.ShortUrl });
        }
    }
}