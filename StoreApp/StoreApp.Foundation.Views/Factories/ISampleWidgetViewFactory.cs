using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StoreApp.Foundation.Views.Factories
{
    public interface ISampleWidgetViewFactory
    {
        Control Create();
    }
}
