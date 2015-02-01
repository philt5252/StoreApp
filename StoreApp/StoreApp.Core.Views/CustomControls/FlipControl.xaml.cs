using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            PreviewMouseDown += OnPreviewMouseDown;
        }

        private void OnPreviewMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            RaiseFlipEvent();
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

        public static readonly DependencyProperty IsEditProperty = DependencyProperty.Register(
            "IsEdit", typeof (bool), typeof (FlipControl), new PropertyMetadata(default(bool)));

        public bool IsEdit
        {
            get { return (bool) GetValue(IsEditProperty); }
            set
            {
                SetValue(IsEditProperty, value);
                RaiseFlipEvent();
            }
        }

        public static readonly RoutedEvent FlipEvent = EventManager.RegisterRoutedEvent(
        "Flip", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FlipControl));

        // Provide CLR accessors for the event 
        public event RoutedEventHandler Flip
        {
            add { AddHandler(FlipEvent, value); }
            remove { RemoveHandler(FlipEvent, value); }
        }

        // This method raises the Tap event 
        void RaiseFlipEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(FlipControl.FlipEvent);
            RaiseEvent(newEventArgs);
        }
        // For demonstration purposes we raise the event when the MyButtonSimple is clicked 
    
    }
}
