using LaunchObserver.Controllers;
using LaunchObserver.Models;

namespace LaunchObserver.Views;

public partial class LaunchesPage : ContentPage
{
    private readonly LaunchController _launchController;
	public List<Launch> UpcomingLaunches { get; set; } = new();

    public LaunchesPage(LaunchController launchController)
	{
		InitializeComponent();
		_launchController = launchController;
		BindingContext = this;
		_ = LoadUpcomingLaunchesAsync();
	}

	private async Task LoadUpcomingLaunchesAsync()
	{
		var launches = await _launchController.GetUpcomingLaunchesAsync();
		UpcomingLaunches = new List<Launch>(launches);
		LaunchList.ItemsSource = null;
		LaunchList.ItemsSource = UpcomingLaunches;
	}

	private async void LaunchCardTapped(object sender, EventArgs e)
	{
		if (sender is Border border && border.BindingContext is Launch selectedLaunch)
		{
			await Navigation.PushAsync(new DetailsPage(selectedLaunch));
        }
	}
}