using System.Drawing;
using System.Windows.Media;

namespace StoreApp.Foundation.Models
{
    public interface IProduct
    {
        int Id { get; set; }
        Bitmap Image { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        string Description { get; set; }
    }
}