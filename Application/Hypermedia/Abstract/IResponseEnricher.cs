using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);

    }
}
