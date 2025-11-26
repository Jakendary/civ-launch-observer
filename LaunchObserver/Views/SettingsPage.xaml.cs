using LaunchObserver.Services;

namespace LaunchObserver.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

	private void TwentyFourHourSwitch_OnToggled(object? sender, ToggledEventArgs e)
	{
		AppPreferences.TimeFormat = !TwentyFourHourSwitch.IsToggled ? "TwelveHour" : "TwentyFourHour";
	}
}