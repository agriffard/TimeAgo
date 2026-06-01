using System.Globalization;
using System.Resources;

namespace TimeAgochi.Resources;

internal static class TimeAgochiResources
{
    private static readonly ResourceManager ResourceManager = new("TimeAgochi.Resources.TimeAgochiResources", typeof(TimeAgochiResources).Assembly);
    private static readonly CultureInfo FallbackCulture = new("en");

    public static string JustNow(CultureInfo culture) => Get("JustNow", culture);
    public static string OneMinuteAgo(CultureInfo culture) => Get("OneMinuteAgo", culture);
    public static string MinutesAgo(CultureInfo culture) => Get("MinutesAgo", culture);
    public static string OneHourAgo(CultureInfo culture) => Get("OneHourAgo", culture);
    public static string HoursAgo(CultureInfo culture) => Get("HoursAgo", culture);
    public static string Yesterday(CultureInfo culture) => Get("Yesterday", culture);
    public static string DaysAgo(CultureInfo culture) => Get("DaysAgo", culture);
    public static string OneMonthAgo(CultureInfo culture) => Get("OneMonthAgo", culture);
    public static string MonthsAgo(CultureInfo culture) => Get("MonthsAgo", culture);
    public static string OneYearAgo(CultureInfo culture) => Get("OneYearAgo", culture);
    public static string YearsAgo(CultureInfo culture) => Get("YearsAgo", culture);
    public static string Future(CultureInfo culture) => Get("Future", culture);

    private static string Get(string key, CultureInfo culture)
    {
        return ResourceManager.GetString(key, culture)
               ?? ResourceManager.GetString(key, FallbackCulture)
               ?? key;
    }
}
