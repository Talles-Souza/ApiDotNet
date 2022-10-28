using Application.Hypermedia.Abstract;

namespace Application.Hypermedia.Filters
{
    public class HyperMediaFileOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
