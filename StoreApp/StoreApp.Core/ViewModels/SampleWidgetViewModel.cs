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
        public override string WidgetName { get { return "Book Sales"; } }
        public override Bitmap Image { get { return null; } }

        public BookSale[] BookSales { get; protected set; }

        public SampleWidgetViewModel(ISampleWidgetViewFactory sampleWidgetViewFactory)
        {
            this.sampleWidgetViewFactory = sampleWidgetViewFactory;

            BookSales = new[]
            {
                new BookSale {Genre = "Fiction", Sales = 40},
                new BookSale {Genre = "Non-Fiction", Sales = 5},
                new BookSale {Genre = "Romance", Sales = 10},
                new BookSale {Genre = "Thriller", Sales = 15},
                new BookSale {Genre = "Mystery", Sales = 10},
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