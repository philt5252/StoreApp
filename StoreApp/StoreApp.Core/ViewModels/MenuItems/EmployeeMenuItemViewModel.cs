﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels.MenuItems
{
    public class EmployeeMenuItemViewModel : MenuItemViewModel
    {
        public override string Text { get { return "Employee"; } }
        public override ICommand MenuCommand { get; protected set; }

        public override String NewText { get { return ""; } }

        public override BitmapImage Image { get { return new BitmapImage(new Uri("Images/employees.png", UriKind.Relative)); } }
        public EmployeeMenuItemViewModel(IEventAggregator eventAggregator)
            :base(eventAggregator)
        {
            MenuCommand = new DelegateCommand(ExecuteMenuCommand);
        }

        private void ExecuteMenuCommand()
        {
         
        }
    }
}
