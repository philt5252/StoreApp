using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using StoreApp.Core.Views.Views;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Views.Factories
{
    public class Sample3WidgetViewFactory : ISample3WidgetViewFactory
    {
        private readonly Func<Sample3WidgetView> createView;

        public Sample3WidgetViewFactory(Func<Sample3WidgetView> createView )
        {
            this.createView = createView;
        }

        public Control Create()
        {
            return createView();
        }
    }
}
