using Microsoft.Extensions.Logging;
using Volkin.UrlRedirector.Application.UseCases.GenerateUrl;
using Volkin.UrlRedirector.Domain.DataAccess.Cache;
using Volkin.UrlRedirector.Domain.DataAccess.Repositories;
using Volkin.UrlRedirector.Domain.Models;

namespace Volkin.UrlRedirector.Application.Services
{
    internal class FullUrlByShortResolver : IFullUrlByShortResolver
    {
        private readonly ILogger _logger;
        private readonly IUrlRepository _urlRepository;
        private readonly IBase36Service _base36Service;
        private readonly IRedisStore _redisStore;

        public FullUrlByShortResolver(ILogger<FullUrlByShortResolver> logger, IUrlRepository urlRepository, IBase36Service base36Service, IRedisStore redisStore)
        {
            _logger = logger;
            _urlRepository = urlRepository;
            _base36Service = base36Service;
            _redisStore = redisStore;
        }

        public async Task<GetRedirectUrlResult?> Resolve(string shortUrl, CancellationToken ct)
        {
            using var childCts = CancellationTokenSource.CreateLinkedTokenSource(ct);

            var getCachedValue = GetFullUrlFromRedis(shortUrl, childCts);
            var getDbValue = GetFullUrlFromDb(shortUrl, childCts);

            var getUrlTask = await Task.WhenAny(getCachedValue, getDbValue);

            if (!String.IsNullOrWhiteSpace(getUrlTask.Result))
                return GetResultFromCompletedTask(getUrlTask, getDbValue, shortUrl, ct);

            getUrlTask = getUrlTask == getCachedValue ? getDbValue : getCachedValue;

            if (!String.IsNullOrWhiteSpace(await getUrlTask))
                return GetResultFromCompletedTask(getUrlTask, getDbValue, shortUrl, ct);

            _logger.LogDebug("Got no value by {ShortUrl}", shortUrl);
            return default;
        }

        private GetRedirectUrlResult GetResultFromCompletedTask(Task<string?> getUrlTask, Task<string?> getDbValueTask,
            string shortUrl, CancellationToken ct)
        {
            if (getUrlTask == getDbValueTask)
            {
                _logger.LogDebug("Got db value {Value} by {ShortUrl}", getUrlTask.Result, shortUrl);

                _ = Task.Run(() => _redisStore.SetString(shortUrl, getUrlTask.Result!, ct), ct);
            }
            else
            {
                _logger.LogDebug("Got cached value {Value} by {ShortUrl}", getUrlTask.Result, shortUrl);
            }

            return new GetRedirectUrlResult { Url = getUrlTask.Result };
        }

        private async Task<string?> GetFullUrlFromDb(string shortUrl, CancellationTokenSource cts)
        {
            var urlId = _base36Service.Decode(shortUrl);

            if (cts.Token.IsCancellationRequested)
                return String.Empty;

            var url = new Url
            {
                Id = urlId,
            };

            if (cts.Token.IsCancellationRequested)
                return String.Empty;

            url = await _urlRepository.GetFullUrl(url, cts.Token);

            if (!String.IsNullOrWhiteSpace(url?.Full))
                cts.Cancel();

            return url?.Full;
        }

        private async Task<string?> GetFullUrlFromRedis(string shortUrl, CancellationTokenSource cts)
        {
            var result = await _redisStore.GetString(shortUrl, cts.Token);

            if (!String.IsNullOrWhiteSpace(result))
                cts.Cancel();

            return result;
        }
    }
}
