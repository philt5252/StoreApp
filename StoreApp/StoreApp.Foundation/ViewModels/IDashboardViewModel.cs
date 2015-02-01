namespace StoreApp.Foundation.ViewModels
{
    public interface IDashboardViewModel
    {
        bool IsEdit { get; }
        void RefreshMenuItems();
    }
}