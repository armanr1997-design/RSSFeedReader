using System.Linq;
using RSSFeedReader.Api.Services;
using Xunit;

namespace integration;

public class AddThenListTests
{
    [Fact]
    public void AddSubscriptionThenRetrieveList_ReturnsAddedSubscription()
    {
        var store = new SubscriptionStore();
        var service = new SubscriptionService(store);

        var addResult = service.AddSubscription("https://example.com/feed");

        Assert.True(addResult.IsSuccess);
        Assert.NotNull(addResult.Value);

        var list = service.GetSubscriptions();

        Assert.Single(list);
        Assert.Equal("https://example.com/feed", list.First().Url);
    }
}
