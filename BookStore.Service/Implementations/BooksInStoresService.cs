


namespace BookStore.Service
{
    using BookStore.Service.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using DATA.ADO.NET;

    public class BooksInStores : IBooksInStoreService
    {

        public BooksInStore Add(BooksInStore item)
        {
            using (var db = new bookStoreEntities())
            {
                var added = db.BooksInStores.Add(item);
                db.SaveChanges();
                return added;
            }
        }

        public BooksInStore Get(int id)
        {
            using (var db = new bookStoreEntities())
            {
                return db.BooksInStores.Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public ICollection<BooksInStore> GetAll()
        {
            using (var db = new bookStoreEntities())
            {
                return db.BooksInStores.ToList();
            }
        }

        public ICollection<Book> GetAllBooksInStore(int id)
        {
            using (var db = new bookStoreEntities())
            {
                var books = new List<Book>();
                var connections = db.BooksInStores.Where(x => x.StoreId == id).ToList();
                foreach (var connection in connections)
                {
                    books.Add(db.Books.Where(b => b.Id == connection.BookId).SingleOrDefault());
                }
                return books;
            }
        }

        public ICollection<Store> GetAllStoresWithBook(int id)
        {
            using (var db = new bookStoreEntities())
            {
                var stores = new List<Store>();
                var connections = db.BooksInStores.Where(x => x.BookId == id).ToList();
                foreach (var connection in connections)
                {
                    stores.Add(db.Stores.Where(b => b.Id == connection.StoreId).SingleOrDefault());
                }
                return stores;

            }
        }

        public BooksInStore Remove(int id)
        {
            using (var db = new bookStoreEntities())
            {
                var toRemove = db.BooksInStores.Where(x => x.Id == id).SingleOrDefault();
                var removed = db.BooksInStores.Remove(toRemove);
                db.SaveChanges();
                return removed;
            }
        }
    }
}