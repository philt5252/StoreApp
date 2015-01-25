using StoreApp.Foundation.Models;

namespace StoreApp.Foundation.DataAccess
{
    public interface IBooksRepository
    {
        IBook[] All();
        void Save(IBook book);
        void Delete(IBook book);
    }
}