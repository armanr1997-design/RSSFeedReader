using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public class SubscriptionService
{
    private readonly SubscriptionStore _store;
    private readonly object _lock = new();

    public SubscriptionService(SubscriptionStore store)
    {
        _store = store;
    }

    public Result<Subscription> AddSubscription(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return Result<Subscription>.Fail("Please enter a valid URL.");
        }

        var trimmed = url.Trim();
        if (!Uri.TryCreate(trimmed, UriKind.Absolute, out var uri))
        {
            return Result<Subscription>.Fail("Please enter a valid URL.");
        }

        if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
        {
            return Result<Subscription>.Fail("URL must start with http:// or https://.");
        }

        var normalizedUrl = NormalizeUrl(uri);

        lock (_lock)
        {
            if (_store.Subscriptions.Any(s => string.Equals(s.Url, normalizedUrl, StringComparison.OrdinalIgnoreCase)))
            {
                return Result<Subscription>.Fail("This subscription already exists.");
            }

            var subscription = new Subscription
            {
                Url = normalizedUrl,
                CreatedAt = DateTime.UtcNow
            };

            _store.Add(subscription);
            return Result<Subscription>.Success(subscription);
        }
    }

    public IReadOnlyCollection<Subscription> GetSubscriptions()
    {
        return _store.Subscriptions;
    }

    private static string NormalizeUrl(Uri uri)
    {
        var normalized = uri.GetComponents(UriComponents.SchemeAndServer | UriComponents.PathAndQuery, UriFormat.UriEscaped);
        return normalized.TrimEnd('/');
    }
}

public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public T? Value { get; private set; }
    public string? ErrorMessage { get; private set; }

    public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };
    public static Result<T> Fail(string message) => new Result<T> { IsSuccess = false, ErrorMessage = message };
}
