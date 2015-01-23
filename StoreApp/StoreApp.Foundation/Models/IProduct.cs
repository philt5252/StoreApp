namespace StoreApp.Foundation.Models
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
    }
}