using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OCR.Core.Models;

namespace OCR.Core.Dao
{
    public interface IRepository<T> where T : class, IModel
    {
        bool IsInitialized { get; }

        Task<int> InsertAllAsync(IEnumerable<T> entities);
        Task<int> InsertAsync(T item);
        Task<int> InsertOrReplaceAsync(T item);
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate, int batchSize, int batchNumber);
        Task<T> FirstOrDefaultAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<int> DeleteAsync(T item);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAllAsync();
        Task<List<T>> AllAsync();
        Task<int> UpdateAsync(T item);
        Task<List<T>> AllAsync(int batchSize, int batchNumber);

        /// <summary>
        /// Checks wether the item exists by the predicate
        /// If exists, the it going to be updated
        /// If NOT exists, the it going to be inserted
        /// </summary>
        /// <param name="item"></param>
        /// <param name="predicate">Checks wether the item exists by the predicate</param>
        /// <returns></returns>
        Task<int> InsertOrUpdateAsync(T item, Expression<Func<T, bool>> predicate);

        Task<int> InsertOrUpdateAsync(T itemFromDb, T item);
    }
}