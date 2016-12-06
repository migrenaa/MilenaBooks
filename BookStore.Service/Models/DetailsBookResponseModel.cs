

namespace BookStore.Service.Models
{
    using BookStore.DATA.ADO.NET;
    using BookStore.Service.Mapping;

    public class DetailsBookResponseModel : IMapFrom<Book>, IMapTo<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string PictureURL { get; set; }
        public int? Rating { get; set; }
        public string Description { get; set; }
    }
}
