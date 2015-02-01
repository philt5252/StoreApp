using StoreApp.Foundation.Models;

namespace StoreApp.Foundation.Controllers
{
    public interface IBooksController
    {
        void Listing();
        void Save(IBook book);
        void Delete(IBook book);
    }
}