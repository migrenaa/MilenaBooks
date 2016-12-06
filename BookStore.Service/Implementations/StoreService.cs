
namespace BookStore.Service
{
    using System;
    using System.Collections.Generic;
    using DATA.ADO.NET;
    using BookStore.Service.Interfaces;
    using System.Linq;

    public class StoreService : IStoreService
    {
        public Store Add(Store store)
        {
            using (var db = new bookStoreEntities())
            {
                var added = db.Stores.Add(store);
                db.SaveChanges();
                return added;
            }
        }

        public Store Get(int id)
        {
            using (var db = new bookStoreEntities())
            {
                return db.Stores.Where(s => s.Id == id).SingleOrDefault();
            }
        }

        public ICollection<Store> GetAll()
        {
            using (var db = new bookStoreEntities())
            {
                return db.Stores.ToList();
            }
        }

        public Store Remove(int id)
        {
            using (var db = new bookStoreEntities())
            {
                var toDelete = db.Stores.Where(s => s.Id == id).SingleOrDefault();
                var deleted = db.Stores.Remove(toDelete);
                var connections = db.BooksInStores.Where(c => c.StoreId == id);
                foreach (var connection in connections)
                {
                    db.BooksInStores.Remove(connection);
                }
                db.SaveChanges();
                return deleted;
            }
        }

        public Store Update(int id, Store store)
        {
            using (var db = new bookStoreEntities())
            {
                var toUpdate = db.Stores.Where(s => s.Id == id).SingleOrDefault();
                toUpdate.Name = store.Name;
                db.SaveChanges();
                return toUpdate;
            }
        }
    }
}