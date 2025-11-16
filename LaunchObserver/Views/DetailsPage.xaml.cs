using LaunchObserver.Models;

namespace LaunchObserver.Views;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(Launch launch)
    {
        InitializeComponent();
        LoadLaunchDetails(launch);
    }

    private async Task LoadLaunchDetails(Launch launch)
    {
        SelectedLaunchImage.Source = new UriImageSource { Uri = new Uri(launch.Image.ImageUrl) };
        SelectedLaunchName.Text = launch.Mission.Name;
        SelectedLaunchTime.Text = $"{launch.LaunchDate}";
        SelectedLaunchProvider.Text = $"\nProvider: {launch.Provider.Name}";
        SelectedLaunchPad.Text = $"Location: {launch.Pad.Name}";
        MissionDetailsTitle.Text = "Mission Details:";
        SelectedLaunchDescription.Text = launch.Mission.Description;
    }
}