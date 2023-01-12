using TanuloKartyak.Views;

namespace TanuloKartyak;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
    }
}
