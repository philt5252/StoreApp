using StoreApp.Foundation.Models;

namespace StoreApp.Foundation.DataAccess
{
    public interface IGamesRepository
    {
        IGame[] All();
        void Save(IGame book);
        void Delete(IGame book); 
    }
}