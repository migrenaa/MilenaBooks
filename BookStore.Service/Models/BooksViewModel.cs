


namespace BookStore.Service
{
    using System.ComponentModel.DataAnnotations;
    using BookStore.Service.Mapping;
    using BookStore.DATA.ADO.NET;
    public class BooksViewModel : IMapFrom<Book>, IMapTo<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1, 100)]
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string PictureURL { get; set; }
        [Range(1, 5)]
        public int? Rating { get; set; }
    }
}
