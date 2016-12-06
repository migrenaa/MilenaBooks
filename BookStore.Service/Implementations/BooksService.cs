
using System;
using System.Linq;
using BookStore.DATA.ADO.NET;
using System.Collections.Generic;
using System.Web;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using Microsoft.Azure;
using BookStore.Service.Models;

namespace BookStore.Service
{
    public class BooksService : IBookService
    {
        public Book Add(Book book)
        {
            using (var db = new bookStoreEntities())
            {
                var added = db.Books.Add(book);
                db.SaveChanges();
                return added;
            }
        }

        public Book Get(int id)
        {
            using (var db = new bookStoreEntities())
            {
                return db.Books.Where(b => b.Id == id).SingleOrDefault();
            }
        }

        public ICollection<Book> GetAll()
        {
            using (var db = new bookStoreEntities())
            {
                return db.Books.ToList();
            }
        }

        public Book Remove(int id)
        {
            using (var db = new bookStoreEntities())
            {
                var toDelete = db.Books.Where(b => b.Id == id).SingleOrDefault();
                var connections = db.BooksInStores.Where(c => c.BookId == id);
                foreach (var connection in connections)
                {
                    db.BooksInStores.Remove(connection);
                }
                var removed = db.Books.Remove(toDelete);
                db.SaveChanges();
                return removed;
            }
        }

        public Book Update(int id, Book book)
        {
            using (var db = new bookStoreEntities())
            {
                var toUpdate = db.Books.Where(x => x.Id == id).SingleOrDefault();
                toUpdate.Author = book.Author;
                toUpdate.Description = book.Description;
                toUpdate.Name = book.Name;
                toUpdate.PictureURL = book.PictureURL;
                toUpdate.Price = book.Price;
                toUpdate.Rating = book.Rating;
                db.SaveChanges();
                return toUpdate;
            }
        }

        public UploadedFileResponseModel UploadFiles(HttpFileCollection files)
        {
            using (var db = new bookStoreEntities())
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                var containername = ConfigurationManager.AppSettings["ContainerName"];
                var container = blobClient.GetContainerReference(containername);
                BlobContainerPermissions permissions = new BlobContainerPermissions();
                permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                container.SetPermissions(permissions);

                
                if (container.CreateIfNotExists())
                {
                    container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }
                var file = files[0];
                var filename = file.FileName;

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);
                blockBlob.UploadFromStream(file.InputStream);
                var uploaded = new UploadedFileResponseModel
                {
                    FileName = filename,
                    URL = blockBlob.Uri.ToString()
                };
                return uploaded;

            }
        }
    }
}
