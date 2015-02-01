using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StoreApp.Foundation.Models
{
    public interface IProduct
    {
        int Id { get; set; }
        BitmapImage Image { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        string Description { get; set; }
    }
}