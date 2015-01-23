using StoreApp.Foundation.Models;

namespace StoreApp.Core.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}