using RestWithAspNet5Example.Hypermedia;
using RestWithAspNet5Example.Hypermedia.Abstract;

namespace RestWithAspNet5Example.Data.DTO
{
    public class BookDTO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public DateTime Launch_Date { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
