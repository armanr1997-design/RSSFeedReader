using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using RSSFeedReader.UI.Pages;
using Xunit;

namespace frontend.components;

public class SubscriptionsPageTests : TestContext
{
    [Fact]
    public void SubscriptionsPage_ShowsFetchedSubscriptionList()
    {
        var json = "[{ \"url\": \"https://example.com/feed\", \"createdAt\": \"2026-05-22T12:00:00Z\" }]";
        Services.AddSingleton(new HttpClient(new MockHttpHandler(json)) { BaseAddress = new Uri("http://localhost:5170/api/") });

        var cut = RenderComponent<Subscriptions>();

        cut.WaitForAssertion(() =>
        {
            Assert.Contains("https://example.com/feed", cut.Markup);
            Assert.Contains("Added", cut.Markup);
        });
    }

    private class MockHttpHandler : HttpMessageHandler
    {
        private readonly string _json;

        public MockHttpHandler(string json)
        {
            _json = json;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_json, System.Text.Encoding.UTF8, "application/json")
            };
            return Task.FromResult(response);
        }
    }
}
