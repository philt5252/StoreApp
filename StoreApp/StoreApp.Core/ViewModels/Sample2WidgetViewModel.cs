using System.Drawing;
using System.Windows.Controls;
using StoreApp.Core.Models;
using StoreApp.Foundation.ViewModels;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.ViewModels
{
    public class Sample2WidgetViewModel :WidgetViewModel
    {
        private readonly ISample2WidgetViewFactory sample2WidgetViewFactory;

        public override string WidgetName
        {
            get { return "Weekly Sales"; }
        }

        public override Bitmap Image
        {
            get { return null; }
        }

        public BookSale[] BookSales { get; protected set; }

        public Sample2WidgetViewModel(ISample2WidgetViewFactory sample2WidgetViewFactory)
        {
            this.sample2WidgetViewFactory = sample2WidgetViewFactory;

            BookSales = new[]
            {
                new BookSale {Genre = "Monday", Sales = 20},
                new BookSale {Genre = "Tuesday", Sales = 7},
                new BookSale {Genre = "Wednesday", Sales = 10},
                new BookSale {Genre = "Thursday", Sales = 15},
                new BookSale {Genre = "Friday", Sales = 12},
            };
        }

        public override Control CreateWidget()
        {
            var view = sample2WidgetViewFactory.Create();
            view.DataContext = CreateWidgetViewModel();

            return view;
        }

        protected override IWidgetViewModel CreateWidgetViewModel()
        {
            return new Sample2WidgetViewModel(sample2WidgetViewFactory);
        }
    }
}