using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Views.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        private bool widgetShowing = false;
        public DashboardView()
        {
            InitializeComponent();

            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            (DataContext as INotifyPropertyChanged).PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "IsEdit")
            {
                gridSystem.IsEdit = (DataContext as IDashboardViewModel).IsEdit;
                slideWidget();

            }
        }

        private void minimizeMenu()
        {
            Storyboard storyBoard = (Storyboard)Application.Current.Resources["MinimizeMenu"];
                storyBoard.Begin();
        }


        private void maximizeMenu()
        {
            if (!widgetShowing)
            {
                Storyboard storyBoard = (Storyboard)Application.Current.Resources["MaximizeMenu"];
                storyBoard.Begin();
            }
        }

        private void minimizeWidget()
        {
            if (widgetShowing)
            {
                Storyboard storyBoard = (Storyboard)Application.Current.Resources["MinimizeWidgetMenu"];
                storyBoard.Begin();
                widgetShowing = false;
            }
        }

        private void maximizeWidget()
        {
            if (!widgetShowing)
            {
                Storyboard storyBoard = (Storyboard)Application.Current.Resources["MaximizeWidgetMenu"];
                storyBoard.Begin();
                widgetShowing = true;
            }
        }
        private void slideWidget()
        {
            if (widgetShowing)
            {
                minimizeWidget();
            }
            else
            {
                maximizeWidget();
                minimizeMenu();
            }
        }
    }
}
