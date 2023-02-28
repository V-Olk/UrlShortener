﻿using MediatR;

namespace Volkin.UrlRedirector.Application.UseCases.Base
{
    public interface IQueryHandler<in TQuery, TResponse>
        : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}