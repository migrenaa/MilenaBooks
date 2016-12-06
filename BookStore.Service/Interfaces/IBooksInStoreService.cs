

namespace BookStore.Service.Interfaces
{
    using DATA.ADO.NET;
    using System.Collections.Generic;
    public interface IBooksInStoreService
    {
        BooksInStore Get(int id);
        ICollection<BooksInStore> GetAll();
        BooksInStore Add(BooksInStore item);
        BooksInStore Remove(int id);
        
        ICollection<Book> GetAllBooksInStore(int id);
        ICollection<Store> GetAllStoresWithBook(int id);
    }
}
