using System.Threading;
using System.Threading.Tasks;
using SQLite.Net.Async;

namespace OCR.Core.Dao
{
    public interface IDatabase
    {
        bool IsInitialized { get;  }

        SQLiteAsyncConnection GetOrCreateConnection();
        Task InitializeSQLiteAsync(CancellationToken cancellationToken);
    }
}