using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using StoreApp.Foundation.Models;

namespace StoreApp.Core.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public BitmapImage Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}