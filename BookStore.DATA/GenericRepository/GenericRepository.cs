

namespace BookStore.DATA.Interfaces
{
    using BookStore.DATA.ADO.NET;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    public class GenericRepository<TEntity> where TEntity : class
    {
        private bookStoreEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(bookStoreEntities context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }


        public TEntity GetByID(int id)
        {
            using (var db = new bookStoreEntities())
            {
                DbSet<TEntity> set = db.Set<TEntity>();
                return set.Find(id);
            }
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if(filter != null)
            {
                query = query.Where<TEntity>(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }


            if (orderBy != null)
            {
                query = orderBy(query).AsQueryable<TEntity>();
            }

            return query;

        }

        public void Insert(TEntity t)
        {
            dbSet.Add(t);
        }

        public void Remove(TEntity item)
        {
            using (var db = new bookStoreEntities())
            {
                DbSet<TEntity> set = db.Set<TEntity>();
                set.Remove(item);
                db.SaveChanges();
            }
        }



        public void Update(int id, TEntity item)
        {
            dbSet.Attach(item);
            context.Entry(item).State = EntityState.Modified;
        }

    }
}
