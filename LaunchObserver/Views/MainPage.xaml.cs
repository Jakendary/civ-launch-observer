using LaunchObserver.Controllers;

namespace LaunchObserver.Views;

public partial class MainPage : ContentPage
{
    private readonly LaunchController _launchController;

    public MainPage(LaunchController launchController)
    {
        InitializeComponent();
        _launchController = launchController;
        LoadNextLaunch();
    }

    private async void LoadNextLaunch()
    {
        var launch = await _launchController.GetNextLaunchAsync();
        NextLaunchImage.Source = new UriImageSource { Uri = new Uri(launch.Image.ImageUrl) };
        NextLaunchName.Text = $"{launch.Mission.Name}";
        NextLaunchTime.Text = $"{launch.LaunchDate}";
        NextLaunchStatus.Text = $"Status: {launch.Status.Short}";

        if (!launch.LaunchDate.HasValue)
        {
            NextLaunchCountdown.Text = "T-00:00:00";
            NextLaunchCountdownBig.Text = "T-00:00:00";
        }

        DateTime launchTime = launch.LaunchDate.Value;

        while (true)
        {
            TimeSpan timeRemaining = launchTime - DateTime.Now;

            if (timeRemaining <= TimeSpan.Zero)
            {
                NextLaunchCountdown.Text = $"T+{timeRemaining:hh\\:mm\\:ss}";
                NextLaunchCountdownBig.Text = $"T+{timeRemaining:hh\\:mm\\:ss}";
            }
            else
            {
                NextLaunchCountdown.Text = $"T-{timeRemaining:hh\\:mm\\:ss}";
                NextLaunchCountdownBig.Text = $"T-{timeRemaining:hh\\:mm\\:ss}";
            }
            await Task.Delay(1000);
        }
    }
}
