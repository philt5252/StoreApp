﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using StoreApp.Foundation.Annotations;

namespace StoreApp.Foundation.ViewModels
{
    public class ViewModelBase : IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsDirty { get; protected set; }
    }
}