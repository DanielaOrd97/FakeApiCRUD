namespace FakeAppApi.Views;

public partial class EditarProductoView : ContentPage
{
	public EditarProductoView()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainView());
    }

}