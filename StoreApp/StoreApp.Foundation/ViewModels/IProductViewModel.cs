using System.ComponentModel;

namespace StoreApp.Foundation.ViewModels
{
    public interface IProductViewModel
    {
        int Id { get; }
        string Name { get; }
        double Price { get; }
    }
}