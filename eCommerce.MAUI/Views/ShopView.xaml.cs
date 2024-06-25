using eCommerce.MAUI.ViewModels;

namespace eCommerce.MAUI.Views;

public partial class ShopView : ContentPage
{
    public ShopView()
    {
        InitializeComponent();
        BindingContext = new InventoryViewModel();
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void MinusQuantity(object sender, EventArgs e)
    {

    }

    private void PlusQuantity(object sender, EventArgs e)
    {

    }
}