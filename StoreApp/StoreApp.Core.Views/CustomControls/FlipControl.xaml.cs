using System;
using System.Windows;
using System.Windows.Controls;

namespace StoreApp.Core.Views.CustomControls
{
    /// <summary>
    /// Interaction logic for FlipControl.xaml
    /// </summary>
    public partial class FlipControl : UserControl
    {
        public FlipControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty FrontDataTemplateProperty = DependencyProperty.Register(
            "FrontDataTemplate", typeof(DataTemplate), typeof(FlipControl), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate FrontDataTemplate
        {
            get { return (DataTemplate) GetValue(FrontDataTemplateProperty); }
            set { SetValue(FrontDataTemplateProperty, value); }
        }

        public static readonly DependencyProperty BackDataTemplateProperty = DependencyProperty.Register(
            "BackDataTemplate", typeof(DataTemplate), typeof(FlipControl), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate BackDataTemplate
        {
            get { return (DataTemplate) GetValue(BackDataTemplateProperty); }
            set { SetValue(BackDataTemplateProperty, value); }
        }

        public static readonly DependencyProperty FrontSourceProperty = DependencyProperty.Register(
            "FrontSource", typeof (Object), typeof (FlipControl), new PropertyMetadata(default(Object)));

        public Object FrontSource
        {
            get { return (Object) GetValue(FrontSourceProperty); }
            set { SetValue(FrontSourceProperty, value); }
        }

        public static readonly DependencyProperty BackSourceProperty = DependencyProperty.Register(
            "BackSource", typeof (Object), typeof (FlipControl), new PropertyMetadata(default(Object)));

        public Object BackSource
        {
            get { return (Object) GetValue(BackSourceProperty); }
            set { SetValue(BackSourceProperty, value); }
        }
    
    }
}
