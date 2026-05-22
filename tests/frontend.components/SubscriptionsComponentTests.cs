using Bunit;
using Microsoft.Extensions.DependencyInjection;
using RSSFeedReader.UI;
using Xunit;

namespace frontend.components;

public class SubscriptionsComponentTests : TestContext
{
    [Fact]
    public void AddSubscriptionComponent_RendersInputAndButton()
    {
        Services.AddSingleton(new HttpClient { BaseAddress = new Uri("http://localhost:5170/api/") });

        var cut = RenderComponent<RSSFeedReader.UI.Components.AddSubscription>(parameters => parameters
            .Add(p => p.OnAdded, (Action<RSSFeedReader.UI.Models.Subscription>)(_ => { })));

        var input = cut.Find("input#feedUrl");
        var button = cut.Find("button");

        Assert.NotNull(input);
        Assert.Equal("Add Subscription", button.TextContent.Trim());
    }

    [Fact]
    public void AddSubscriptionComponent_ShowsValidationMessageForInvalidUrl()
    {
        Services.AddSingleton(new HttpClient { BaseAddress = new Uri("http://localhost:5170/api/") });

        var cut = RenderComponent<RSSFeedReader.UI.Components.AddSubscription>(parameters => parameters
            .Add(p => p.OnAdded, (Action<RSSFeedReader.UI.Models.Subscription>)(_ => { })));

        cut.Find("input#feedUrl").Change("not-a-url");
        cut.Find("button").Click();

        Assert.Contains("Please enter a valid URL", cut.Markup);
    }
}
