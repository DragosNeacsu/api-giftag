﻿using System.Collections.Generic;

public class Settings
{
    public static string PaypalUrl => "https://www.sandbox.paypal.com/cgi-bin/webscr";
    public static string PaypalEmail => "tickets.giftag-facilitator@gmail.com";
    public static string PaypalAuthToken => "HvNvBW2Jk_ItGbPe9XjhVlYu-LfQgGp_xbQzmPkk-0Dg1uo1tr22cqVjvWq";

    public static string FromName => "Giftag";
    public static string FromEmail => "tickets.giftag@gmail.com";
    public static string SendGridKey => "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";

    public static string Database => "Server=tcp:db-giftag.database.windows.net,1433;Initial Catalog=giftag;Persist Security Info=False;User ID=giftag;Password=Kmgi12345!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
}

