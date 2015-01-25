using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StoreApp.Core.Views.Views;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Views.Factories
{
    public class BookViewFactory : IBookViewFactory
    {
        private readonly Func<BookView> createView;

        public BookViewFactory(Func<BookView> createView )
        {
            this.createView = createView;
        }

        public FrameworkElement Create()
        {
            return createView();
        }
    }
}
