namespace LaunchObserver.Services;

public class AppPreferences
{
    static public string TimeFormat
    {
        get
        {
            return Preferences.Get("TimeFormat", "TwelveHour");
        }
        set
        {
            Preferences.Set("TimeFormat", value);
        }
    }
}