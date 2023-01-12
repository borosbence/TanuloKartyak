namespace TanuloKartyak.Views;

public partial class IndexPage : ContentPage
{
	public IndexPage()
	{
		InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}