using SQLite.Net.Attributes;

namespace OCR.Core.Models
{
    public abstract class BaseModel : IModel
    {
        #region IModel implementation
        [PrimaryKey, AutoIncrement]
        public int KeyId { get; set; }

        #endregion
    }
}