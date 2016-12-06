


namespace BookStore.Service.Interfaces
{
    using BookStore.DATA.ADO.NET;
    using System.Collections.Generic;
    using System.Linq;
    public interface IStoreService
    {
        ICollection<Store> GetAll();
        Store Get(int id);
        Store Add(Store store);
        Store Update(int id, Store store);
        Store Remove(int id);

    }
}
