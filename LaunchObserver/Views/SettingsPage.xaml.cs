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
		if (TwentyFourHourSwitch.IsToggled)
		{
			AppPreferences.TimeFormat = "TwentyFourHour";
		}
		else
		{
			AppPreferences.TimeFormat = "TwelveHour";
		}
	}
}