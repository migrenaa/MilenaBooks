using BookStore.DATA.ADO.NET;
using BookStore.DATA.UnitOfWork;
using BookStore.Service;
using BookStore.Service.Interfaces;
using BookStore.Service.Mapping;
using BookStore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IBookService books;
        private readonly IBooksInStoreService booksInStores;

        public BooksController(IBookService service, IBooksInStoreService serviceBooksInStore)
        {
            this.booksInStores = serviceBooksInStore;
            this.books = service;
        }

        [Route("api/upload")]
        [HttpPost]
        public IHttpActionResult UploadDocument()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
         

            if (files == null || files.Count < 1)
            {
                return BadRequest();
            }

            var uploaded = books.UploadFiles(files);
            
            return Ok(uploaded);
        }

        // GET api/book
        public IHttpActionResult GetAll()
        {
            return Ok(books.GetAll().AsQueryable().To<BooksViewModel>());
        }

        //GET api/book/1
        public IHttpActionResult Get(int id)
        {
            var book = books.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<DetailsBookResponseModel>(book));
        }

        //POST api/book
        public IHttpActionResult Post(BooksRequestModel book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var added = books.Add(Mapper.Map<Book>(book));
            return Ok(Mapper.Map<DetailsBookResponseModel>(added));
        }



        //DELETE api/book/1
        public IHttpActionResult Delete(int id)
        {
            var toDelete = books.Get(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            var deleted = books.Remove(id);
            return Ok(Mapper.Map<DetailsBookResponseModel>(deleted));
            
        }

        //PUT api/book/1
        public IHttpActionResult Put(int id, BooksRequestModel book)
        {
            var toUpdate = books.Get(id);
            if (toUpdate == null)
            {
                return NotFound();
            }

            if (book == null)
            {
                return BadRequest();
            }

            var updated = books.Update(id, Mapper.Map<Book>(book));
            return Ok(Mapper.Map<DetailsBookResponseModel>(updated));
        }


        [HttpGet]
        [Route("api/books/{id}/store/")]
        //GET api/store/{id}
        public IHttpActionResult GetAllStoresWithBook(int id)
        {
            var book = books.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            var stores = booksInStores.GetAllStoresWithBook(id);
            return Ok(stores.AsQueryable().To<StoreViewModel>());
        }
    }
}