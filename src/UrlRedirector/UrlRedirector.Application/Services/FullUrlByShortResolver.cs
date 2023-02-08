﻿using Microsoft.Extensions.Logging;
using Volkin.UrlRedirector.Application.UseCases.GenerateUrl;
using Volkin.UrlRedirector.Domain.DataAccess.Cache;
using Volkin.UrlRedirector.Domain.DataAccess.Repositories.Actors;
using Volkin.UrlRedirector.Domain.Models;

namespace Volkin.UrlRedirector.Application.Services
{
    internal class FullUrlByShortResolver : IFullUrlByShortResolver
    {
        private readonly ILogger _logger;
        private readonly IUrlsRepository _urlsRepository;
        private readonly IBase36Service _base36Service;
        private readonly IRedisStore _redisStore;

        public FullUrlByShortResolver(ILogger<FullUrlByShortResolver> logger, IUrlsRepository urlsRepository, IBase36Service base36Service, IRedisStore redisStore)
        {
            _logger = logger;
            _urlsRepository = urlsRepository;
            _base36Service = base36Service;
            _redisStore = redisStore;
        }

        public async Task<GetRedirectUrlResult> Resolve(string shortUrl, CancellationToken ct)
        {
            using var childCts = CancellationTokenSource.CreateLinkedTokenSource(ct);

            var getCachedValue = GetFullUrlFromRedis(shortUrl, childCts);
            var getDbValue = GetFullUrlFromDb(shortUrl, childCts);

            var tasksResult = await Task.WhenAll(getCachedValue, getDbValue);

            if (tasksResult[0] is not null)
            {
                _logger.LogInformation("Got cached value {Value} by {ShortUrl}", tasksResult[0], shortUrl);

                return new GetRedirectUrlResult { Url = tasksResult[0] };
            }

            if (tasksResult[1] is not { } dbResult)
            {
                _logger.LogInformation("Got no value {Value} by {ShortUrl}", tasksResult[0], shortUrl);

                return new GetRedirectUrlResult();
            }
            _logger.LogInformation("Got db value {Value} by {ShortUrl}", tasksResult[0], shortUrl);

            _ = Task.Run(async () => await _redisStore.SetString(shortUrl, dbResult, ct), ct);

            return new GetRedirectUrlResult { Url = dbResult };
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

            url = await _urlsRepository.GetFullUrl(url, cts.Token);

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