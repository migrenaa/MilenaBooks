

namespace BookStore.Controllers
{
    using BookStore.Service.Interfaces;
    using BookStore.Service.Models;
    using DATA.ADO.NET;
    using Service;
    using Service.Mapping;
    using System.Linq;
    using System.Web.Http;
    public class StoreController : BaseController
    {
        private readonly IStoreService stores;
        private readonly IBooksInStoreService booksInStore;
        private readonly IBookService books;

        public StoreController(IStoreService service, IBooksInStoreService serviceBIS, IBookService books)
        {
            this.books = books;
            this.stores = service;
            this.booksInStore = serviceBIS;
        }

        // GET api/store
        public IHttpActionResult Get()
        {
            return Ok(stores.GetAll().AsQueryable().To<StoreViewModel>());
        }

        //GET api/store/1
        [Route("api/store/{id}")]
        public IHttpActionResult Get(int id)
        {
            var store = stores.Get(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<StoreViewModel>(store));
        }

        //POST api/store
        public IHttpActionResult Post(StoreRequestModel store)
        {
            if (store == null)
            {
                return BadRequest();
            }
            var added = stores.Add(Mapper.Map<Store>(store));
            return Ok(Mapper.Map<StoreViewModel>(added));
        }

        //DELETE api/store/1
        [Route("api/store/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var toDelete = stores.Get(id);
            if (toDelete == null)
            {
                return NotFound();
            }
            var deleted = stores.Remove(id);
            return Ok(Mapper.Map<StoreViewModel>(deleted));
        }

        //PUT api/store/1
        [Route("api/store/{id}")]
        public IHttpActionResult Put(int id, StoreViewModel store)
        {
            var toUpdate = stores.Get(id);
            if (toUpdate == null)
            {
                return NotFound();
            }

            if (store == null)
            {
                return BadRequest();
            }
            var updated = stores.Update(id, Mapper.Map<Store>(store));
            return Ok(Mapper.Map<StoreViewModel>(updated));
        }

        [HttpGet]
        [Route("api/store/{id}/books/")]
        //GET api/store/{id}
        public IHttpActionResult GetAllBooksInStore(int id)
        {
            var store = this.stores.Get(id);
            if (store == null)
            {
                return NotFound();
            }
            var books = booksInStore.GetAllBooksInStore(id);
            return Ok(books.AsQueryable().To<BooksViewModel>());
        }

        [HttpPost]
        [Route("api/store/book")]
        //POST api/store/books/
        public IHttpActionResult AddBookInStore(BooksInStoreRequestModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var added = booksInStore.Add(Mapper.Map<BooksInStore>(item));
            var book = books.Get(added.BookId);
            return Ok(Mapper.Map<BooksViewModel>(book));

        }

        //DELETE api/book/storebooks/1
        [HttpDelete]
        [Route("api/store/{id}/books")]
        public IHttpActionResult DeleteBookStoreRelationship([FromUri] int id)
        {
            var toRemove = booksInStore.Remove(id);
            if (toRemove == null)
            {
                return NotFound();
            }
            var removedBook = books.Get(toRemove.BookId);
            return Ok(Mapper.Map<DetailsBookResponseModel>(removedBook));
        }

    }
}