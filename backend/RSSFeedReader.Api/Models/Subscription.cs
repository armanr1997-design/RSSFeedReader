namespace RSSFeedReader.Api.Models;

public class Subscription
{
    public string Url { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}
