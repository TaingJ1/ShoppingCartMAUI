using eCommerce.MAUI.ViewModels;

namespace eCommerce.MAUI.Views;

public partial class InventoryView : ContentPage
{
	public InventoryView()
	{
		InitializeComponent();
		BindingContext = new InventoryViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Product");
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryViewModel).Refresh();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InventoryViewModel)?.Refresh();
    }
}