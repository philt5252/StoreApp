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
    public class Sample2WidgetViewFactory : ISample2WidgetViewFactory
    {
             private readonly Func<Sample2WidgetView> createView;

        public Sample2WidgetViewFactory(Func<Sample2WidgetView> createView)
        {
            this.createView = createView;
        }

        public Control Create()
        {
            return createView();
        }
    }
}
