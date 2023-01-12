using TanuloKartyak.ViewModels;

namespace TanuloKartyak.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}