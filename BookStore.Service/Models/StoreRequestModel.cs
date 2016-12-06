
namespace BookStore.Service.Models
{
    using BookStore.DATA.ADO.NET;
    using BookStore.Service.Mapping;
    public class StoreRequestModel : IMapTo<Store>
    {
        public string Name { get; set; }
    }
}
