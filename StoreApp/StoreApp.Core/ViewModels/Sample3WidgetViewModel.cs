using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Controls;
using StoreApp.Core.Models;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.ViewModels
{
    public class Sample3WidgetViewModel : WidgetViewModel
    {
        private readonly ISample3WidgetViewFactory sample3WidgetViewFactory;

        public override string WidgetName
        {
            get { return "Top Books"; }
        }

        public override Bitmap Image
        {
            get { return null; }
        }

        public IBook[] Books { get; protected set; }

        public Sample3WidgetViewModel(ISample3WidgetViewFactory sample3WidgetViewFactory)
        {
            this.sample3WidgetViewFactory = sample3WidgetViewFactory;
            Books = new IBook[]
            {
                new Book{Name = "Book1"}, 
                new Book{Name = "Book2"}, 
                new Book{Name = "Book3"}, 
                new Book{Name = "Book4"}, 
                new Book{Name = "Book5"}
            };
        }

        public override Control CreateWidget()
        {
            var view = sample3WidgetViewFactory.Create();
            view.DataContext = CreateWidgetViewModel();

            return view;
        }

        protected override IWidgetViewModel CreateWidgetViewModel()
        {
            return new Sample3WidgetViewModel(sample3WidgetViewFactory);
        }
    }
}