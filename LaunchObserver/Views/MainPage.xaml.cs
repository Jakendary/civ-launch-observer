using LaunchObserver.Controllers;
using LaunchObserver.Services;

namespace LaunchObserver.Views;

public partial class MainPage : ContentPage
{
    private readonly LaunchController _launchController;

    public MainPage(LaunchController launchController)
    {
        InitializeComponent();
        _launchController = launchController;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadNextLaunch();
    }

    private async void LoadNextLaunch()
    {
        try
        {
            var launch = await _launchController.GetNextLaunchAsync();
            NextLaunchImage.Source = new UriImageSource { Uri = new Uri(launch.Image.ImageUrl) };
            NextLaunchName.Text = $"{launch.Mission.Name}";

            if (AppPreferences.TimeFormat == "TwelveHour")
            {
                NextLaunchTime.Text = launch.LaunchDate.Value.ToString("M/d/yyyy h:mm tt");
            }
            else
            {
                NextLaunchTime.Text = launch.LaunchDate.Value.ToString("M/d/yyyy HH:mm");
            }
        
            NextLaunchStatus.Text = $"Status: {launch.Status.Short}";

            if (!launch.LaunchDate.HasValue)
            {
                NextLaunchCountdown.Text = "T-00:00:00";
                NextLaunchCountdownBig.Text = "T-00:00:00";
            }
            else
            {
                DateTime launchTime = launch.LaunchDate.Value;

                while (true)
                {
                    TimeSpan timeRemaining = launchTime - DateTime.Now;
                    var prefix = timeRemaining.TotalSeconds >= 0 ? "T-" : "T+";
                
                    NextLaunchCountdown.Text = $"{prefix}{timeRemaining:hh\\:mm\\:ss}";
                    NextLaunchCountdownBig.Text = $"{prefix}{timeRemaining:hh\\:mm\\:ss}";
                
                    await Task.Delay(1000);
                }
            }
        }
        catch
        {
            NextLaunchName.Text = "CONNECTION ERROR";
            NextLaunchTime.Text = "Please try again later";
        }
    }
}
