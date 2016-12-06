

namespace BookStore.Service
{
    using BookStore.Service.Models;
    using DATA.ADO.NET;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public interface IBookService
    {
        ICollection<Book> GetAll();
        Book Get(int id);
        Book Add(Book book);
        Book Update(int id, Book book);
        Book Remove(int id);
        UploadedFileResponseModel UploadFiles(HttpFileCollection files);

    }
}
