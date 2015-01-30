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
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using StoreApp.Foundation.Views;

namespace StoreApp.Core.Views.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean menuShowing;
        private Boolean widgetShowing;
        private IRegionManager regionManager;
        public MainWindow()
        {
            
            regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            RegionManager.SetRegionManager(this, regionManager);


            InitializeComponent();
         
            RegionManager.UpdateRegions();

            Closing += OnClosing;
            menuShowing = true;
            widgetShowing = false;
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            regionManager.Regions.Remove("MainRegion");
        }

        private void MenuButton_OnClick(object sender, RoutedEventArgs e)
        {
      
            if (menuShowing)
            {
                Storyboard storyBoard = (Storyboard)this.Resources["MinimizeMenu"];
                storyBoard.Begin();
                menuShowing = false;

            }
            else
            {
                Storyboard storyBoard = (Storyboard)this.Resources["MaximizeMenu"];
                storyBoard.Begin();
                menuShowing = true;
                if (widgetShowing)
                {
                    Storyboard storyBoard1 = (Storyboard)this.Resources["MinimizeWidgetMenu"];
                    storyBoard1.Begin();
                    widgetShowing = false;
                }
            }
        }

        private void WidgetButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (widgetShowing)
            {
                Storyboard storyBoard = (Storyboard)this.Resources["MinimizeWidgetMenu"];
                storyBoard.Begin();
                widgetShowing = false;
            }
            else
            {
                Storyboard storyBoard = (Storyboard)this.Resources["MaximizeWidgetMenu"];
                storyBoard.Begin();
                widgetShowing = true;
                if (menuShowing)
                {
                    Storyboard storyBoard1 = (Storyboard)this.Resources["MinimizeMenu"];
                    storyBoard1.Begin();
                    menuShowing = false;
                }
            }
        }
    }
}
