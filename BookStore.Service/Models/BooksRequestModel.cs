


namespace BookStore.Service
{
    using System.ComponentModel.DataAnnotations;
    using BookStore.Service.Mapping;
    using BookStore.DATA.ADO.NET;
    public class BooksRequestModel : IMapFrom<Book>, IMapTo<Book>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }

        public string PictureURL { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        public string Description { get; set; }

        //public void CreateMappings(IMapperConfiguration configuration)
        //{
        //    configuration.CreateMap<BooksRequestModel, Book>()
        //        .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
        //        .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author))
        //        .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price));

        //}
    }
}