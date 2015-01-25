﻿using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            menuShowing = true;

            InitializeComponent();

            RegionAdapterMappings regionAdapterMappings = ServiceLocator.Current.GetInstance<RegionAdapterMappings>();
            IRegionAdapter regionAdapter = regionAdapterMappings.GetMapping(typeof(ContentControl));
            IRegion region = regionAdapter.Initialize(contentControl, Regions.MainRegion);

            //IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            //regionManager.Regions.Add(region);

            RegionManager.UpdateRegions();
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
            }
        }
    }
}
