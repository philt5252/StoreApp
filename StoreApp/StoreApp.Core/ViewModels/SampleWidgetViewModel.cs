using System.Drawing;
using System.Windows;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class SampleWidgetViewModel : WidgetViewModel
    {
        public override string WidgetName { get { return "SampleWidgetName"; } }
        public override Bitmap Image { get { return null; } }
        public override FrameworkElement CreateWidget()
        {
            var widgetViewModel = CreateWidgetViewModel();

            throw new System.NotImplementedException();
        }

        protected override IWidgetViewModel CreateWidgetViewModel()
        {
            return new SampleWidgetViewModel();
        }
    }
}