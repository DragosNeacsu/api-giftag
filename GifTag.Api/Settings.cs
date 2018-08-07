using Microsoft.Extensions.Configuration;

public class Settings
{
    public static string PaypalUrl { get; set; }
    public static string PaypalEmail { get; set; }
    public static string PaypalAuthToken { get; set; }

    public static string FromName { get; set; }
    public static string FromEmail { get; set; }
    public static string SendGridKey { get; set; }
    public static string UiUrl { get; set; }
    public static bool IsPaypalLive { get; internal set; }
}

