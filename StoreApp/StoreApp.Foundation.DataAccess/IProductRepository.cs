using StoreApp.Foundation.Models;

namespace StoreApp.Foundation.DataAccess
{
    public interface IProductRepository
    {
        IProduct[] All();

        IProduct Find(int id);

        void Save(IProduct product);

        void Delete(IProduct product);
    }
}