using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StoreApp.Core.Views
{
    public class TileCanvas : Canvas
    {
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(TileCanvas), new UIPropertyMetadata(null, OnImageSourceChanged));

        private static void OnImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            ((TileCanvas)o).Rebuild();
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            Rebuild();
        }

        private void Rebuild()
        {
            if (ImageSource == null)
            {
                return;
            }

            var size = RenderSize;
            Children.Clear();
            var width = (int)ImageSource.Width;
            var height = (int)ImageSource.Height;
            for (int x = 0; x < size.Width; x += width)
            {
                for (int y = 0; y < size.Height; y += height)
                {
                    var image = new Image { Source = ImageSource };
                    Canvas.SetLeft(image, x);
                    Canvas.SetTop(image, y);
                    Children.Add(image);
                }
            }
            Clip = new RectangleGeometry(new Rect(size));
        }
    }
}
