


namespace BookStore.Service.Models
{
    using System.ComponentModel.DataAnnotations;
    using BookStore.Service.Mapping;
    using BookStore.DATA.ADO.NET;
    public class StoreViewModel : IMapFrom<Store>, IMapTo<Store>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
