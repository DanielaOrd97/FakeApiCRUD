namespace FakeAppApi.Views;

public partial class AgregarProductoView : ContentPage
{
	public AgregarProductoView()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainView());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainView());
    }
}