using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using StoreApp.Core.Models;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.ViewModels
{
    public class SampleWidgetViewModel : WidgetViewModel
    {
        private readonly ISampleWidgetViewFactory sampleWidgetViewFactory;
        public override string WidgetName { get { return "SampleWidgetName"; } }
        public override Bitmap Image { get { return null; } }

        public BookSale[] BookSales { get; protected set; }

        public SampleWidgetViewModel(ISampleWidgetViewFactory sampleWidgetViewFactory)
        {
            this.sampleWidgetViewFactory = sampleWidgetViewFactory;

            BookSales = new[]
            {
                new BookSale {Genre = "Genre1", Sales = 40},
                new BookSale {Genre = "Genre2", Sales = 5},
                new BookSale {Genre = "Genre3", Sales = 10},
                new BookSale {Genre = "Genre4", Sales = 15},
                new BookSale {Genre = "Genre5", Sales = 10},
            };
        }

        public override Control CreateWidget()
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