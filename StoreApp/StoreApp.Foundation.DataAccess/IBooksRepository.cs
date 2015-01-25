using StoreApp.Foundation.Models;

namespace StoreApp.Foundation.DataAccess
{
    public interface IBooksRepository
    {
        IBook[] All();
    }
}