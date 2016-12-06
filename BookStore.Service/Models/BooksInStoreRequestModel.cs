


namespace BookStore.Service.Models
{
    using System.ComponentModel.DataAnnotations;
    using BookStore.Service.Mapping;
    using DATA.ADO.NET;

    public class BooksInStoreRequestModel : IMapTo<BooksInStore>
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int StoreId { get; set; }
        
            

       /* public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<BooksInStoreRequestModel, BooksInStores>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price));
        }
        */
    }
}
