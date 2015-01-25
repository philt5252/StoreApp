using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreApp.Foundation.Views.Factories
{
    public interface IMainWindowFactory
    {
        Window Create();
    }
}
