using System.Drawing;
using System.Windows;
using StoreApp.Foundation.ViewModels;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.ViewModels
{
    public class SampleWidgetViewModel : WidgetViewModel
    {
        private readonly ISampleWidgetViewFactory sampleWidgetViewFactory;
        public override string WidgetName { get { return "SampleWidgetName"; } }
        public override Bitmap Image { get { return null; } }

        public SampleWidgetViewModel(ISampleWidgetViewFactory sampleWidgetViewFactory)
        {
            this.sampleWidgetViewFactory = sampleWidgetViewFactory;
        }

        public override FrameworkElement CreateWidget()
        {
            var widgetViewModel = CreateWidgetViewModel();

            var widgetView = sampleWidgetViewFactory.Create();

            widgetView.DataContext = widgetViewModel;

            return widgetView;
        }

        protected override IWidgetViewModel CreateWidgetViewModel()
        {
            return new SampleWidgetViewModel(sampleWidgetViewFactory);
        }
    }
}