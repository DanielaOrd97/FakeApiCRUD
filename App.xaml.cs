using FakeAppApi.Views;

namespace FakeAppApi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new MainView());
        }
    }
}
