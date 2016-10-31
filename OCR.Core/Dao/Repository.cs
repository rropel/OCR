using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OCR.Core.Helpers;
using OCR.Core.Models;

namespace OCR.Core.Dao
{
    public class Repository<T> : IRepository<T> where T : class, IModel, new()
    {
        private readonly AsyncLock _mutex = new AsyncLock();

        #region Declarations

        private readonly IDatabase _context;

        #endregion

        #region Properties

        protected IDatabase Context
        {
            get { return _context; }
        }

        #endregion

        #region Constructors

        public Repository(IDatabase context)
        {
            this._context = context;
        }

        #endregion

        #region Public Methods

        public bool IsInitialized
        {
            get { return _context.IsInitialized; }
        }

        public async Task<int> InsertAllAsync(IEnumerable<T> items)
        {
            return await this._context.GetOrCreateConnection().InsertAllAsync(items);
        }

        public async Task<int> InsertAsync(T item)
        {
            return await this._context.GetOrCreateConnection().InsertAsync(item);
        }

        public async Task<int> InsertOrReplaceAsync(T item)
        {
            return await this._context.GetOrCreateConnection().InsertOrReplaceAsync(item);
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.GetOrCreateConnection().Table<T>().Where(predicate).ToListAsync();
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate, int batchSize, int batchNumber)
        {
            var elementToSkip = batchSize * batchNumber;

            return
                await this._context.GetOrCreateConnection().Table<T>().Where(predicate).Skip(elementToSkip).Take(batchSize).ToListAsync();
        }

        public async Task<int> UpdateAsync(T item)
        {
            return await this._context.GetOrCreateConnection().UpdateAsync(item);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.GetOrCreateConnection().Table<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> FirstOrDefaultAsync()
        {
            return await this._context.GetOrCreateConnection().Table<T>().FirstOrDefaultAsync();
        }

        public async Task<int> DeleteAsync(T item)
        {
            return await this._context.GetOrCreateConnection().DeleteAsync(item);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await this._context.GetOrCreateConnection().DeleteAsync(id);
        }

        public async Task<int> DeleteAllAsync()
        {
            return await this._context.GetOrCreateConnection().DeleteAllAsync<T>();
        }

        public async Task<List<T>> AllAsync()
        {
            return await this._context.GetOrCreateConnection().Table<T>().ToListAsync();
        }

        public async Task<List<T>> AllAsync(int batchSize, int batchNumber)
        {
            var elementToSkip = batchSize*batchNumber;

            return
                await this._context.GetOrCreateConnection().Table<T>().Skip(elementToSkip).Take(batchSize).ToListAsync();
        }

        public async Task<int> InsertOrUpdateAsync(T item, Expression<Func<T, bool>> predicate)
        {
            using (await _mutex.LockAsync())
            {
                var firstOrDefault = await this.FirstOrDefaultAsync(predicate);

                return await InsertOrUpdateAsync(firstOrDefault, item);
            }
        }

        public async Task<int> InsertOrUpdateAsync(T itemFromDb, T item)
        {
            if (itemFromDb == null)
            {
                return await this.InsertAsync(item);
            }
            else
            {
                item.KeyId = itemFromDb.KeyId;
                return await this.UpdateAsync(item);
            }
        }
        #endregion
    }
}