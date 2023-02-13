using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithAspNet5Example.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);

        Task Enrich(ResultExecutingContext context);
    }
}
