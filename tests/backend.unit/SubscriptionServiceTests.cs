using RSSFeedReader.Api.Services;
using Xunit;

namespace backend.unit;

public class SubscriptionServiceTests
{
    [Fact]
    public void AddSubscription_ValidUrl_AddsSuccessfully()
    {
        var store = new SubscriptionStore();
        var service = new SubscriptionService(store);

        var result = service.AddSubscription("https://example.com/feed");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal("https://example.com/feed", result.Value!.Url);
        Assert.Single(store.Subscriptions);
    }

    [Fact]
    public void AddSubscription_DuplicateUrl_ReturnsFailure()
    {
        var store = new SubscriptionStore();
        var service = new SubscriptionService(store);

        service.AddSubscription("https://example.com/feed");
        var duplicate = service.AddSubscription("https://example.com/feed");

        Assert.False(duplicate.IsSuccess);
        Assert.Equal("This subscription already exists.", duplicate.ErrorMessage);
        Assert.Single(store.Subscriptions);
    }

    [Fact]
    public void AddSubscription_InvalidUrl_ReturnsFailure()
    {
        var store = new SubscriptionStore();
        var service = new SubscriptionService(store);

        var result = service.AddSubscription("not-a-url");

        Assert.False(result.IsSuccess);
        Assert.Equal("Please enter a valid URL.", result.ErrorMessage);
        Assert.Empty(store.Subscriptions);
    }

    [Fact]
    public void AddSubscription_EmptyUrl_ReturnsFailure()
    {
        var store = new SubscriptionStore();
        var service = new SubscriptionService(store);

        var result = service.AddSubscription("   ");

        Assert.False(result.IsSuccess);
        Assert.Equal("Please enter a valid URL.", result.ErrorMessage);
        Assert.Empty(store.Subscriptions);
    }
}
